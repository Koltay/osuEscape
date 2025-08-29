using osuEscape.Properties;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace osuEscape.Models
{
    internal class API
    {
        //! IMPORTANT currently class was called by SettingsForm.cs->btnAuthorize_Click
        // develop a oauth application
        // reference: https://osu.ppy.sh/docs/index.html#authentication
        // first we need user to login on the website and authorize our application
        // respone: authorization code                                                  
        // then we can use the authorization code to get access token and refresh token
        // respone: access token, refresh token, expires in xxx 
        // we can use the access token to get user data and upload score <-- Current progress (The very next day)

        private readonly string REDIRECT_URI = "http://localhost:10010/"; // Same as website redirect_uri
        private readonly static HttpClient _httpClient = new();
        public API() {

        }

        async public static Task<JsonElement> getUserInfoByUserName(string userName)
        {
            Debug.WriteLine("Method called: getUserIdByUserName(username)");
            Debug.WriteLine("Access toekn: " + Properties.Settings.Default.access_token);
            // get user data by user name
            var result = await Task.Run(async () =>
            {
                // setup request headers
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Accept", "application/json");
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Content-Type", "application/json");
                // add bearer token to header
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Properties.Settings.Default.access_token);

                // send get request
                var userResponse = await _httpClient.GetAsync("https://osu.ppy.sh/api/v2/users/@" + userName + "/");
                //receive response
                var responseMessage = await userResponse.Content.ReadAsStringAsync();
                // conver responseMessage to json
                var responseJson = System.Text.Json.JsonDocument.Parse(responseMessage);
                return responseJson.RootElement;
            });
            return result;
        }

        async public Task<int> tryLogin()
        {
            Debug.WriteLine("Method called: tryLogin");
            // if both token are empty, need to get access first
            // elise if expires_in is passed, need to use refresh token to get new access token
            // else if both token are not empty and expires_in is not passed, we can directly use the access token to get user
            
            if (string.IsNullOrEmpty(Properties.Settings.Default.access_token) || string.IsNullOrEmpty(Properties.Settings.Default.refresh_token))
            {
                return await getAccessTokenByAuth();
            }
            else if (Properties.Settings.Default.expires_in <= System.DateTime.Now && !string.IsNullOrEmpty(Properties.Settings.Default.refresh_token))
            {
                return await getAccessTokenByRefreshToken();
            }

            return 1; // with valid expires_in and both token
        }
        async private Task<int> getAccessTokenByAuth()
        {
            Debug.WriteLine("Method called: getAccessTokenByAuth");
            // get the authorization code
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://osu.ppy.sh/oauth/authorize?client_id=43679&response_type=code&scope=public",
                UseShellExecute = true
            });

            int result = await Task.Run(async () => 
            {
                //string code = "";
                using (var listener = new System.Net.HttpListener())
                {
                    listener.Prefixes.Add(REDIRECT_URI);
                    listener.Start();
                    var context = listener.GetContext();
                    var request = context.Request;
                    var codeResponse = context.Response;
                    var codeResponseString = "<html><body>You can close this window now.</body></html>";
                    var buffer = System.Text.Encoding.UTF8.GetBytes(codeResponseString);
                    codeResponse.ContentLength64 = buffer.Length;
                    var output = codeResponse.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    output.Close();
                    listener.Stop();
                    Debug.WriteLine("auth_token : " + request.QueryString["code"]);
//
                    HttpClient client = new System.Net.Http.HttpClient();

                    // setup request headers
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Accept", "application/json");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Content-Type", "application/x-www-form-urlencoded");

                    // setup request body
                    var values = new Dictionary<string, string>
                    {
                        { "client_id", "43679" },
                        { "client_secret", Properties.Settings.Default.client_secret },
                        { "code", request.QueryString["code"] },
                        { "grant_type", "authorization_code" }
                    };

                    // convert to form url encoded content
                    var content = new FormUrlEncodedContent(values);
                    // send post request
                    var AccessResponse = await client.PostAsync("https://osu.ppy.sh/oauth/token", content);
                    //receive response
                    var responseMessage = await AccessResponse.Content.ReadAsStringAsync();
                    Debug.WriteLine("Access Token Response: " + responseMessage);
                    // store the access token and refresh token in settings
                    var responseJson = System.Text.Json.JsonDocument.Parse(responseMessage);
                    Properties.Settings.Default.access_token = responseJson.RootElement.GetProperty("access_token").GetString();
                    Properties.Settings.Default.refresh_token = responseJson.RootElement.GetProperty("refresh_token").GetString();
                    Properties.Settings.Default.expires_in = System.DateTime.Now.AddSeconds(responseJson.RootElement.GetProperty("expires_in").GetInt32());
                    // set isAPIKeyVerified as true
                    Properties.Settings.Default.isAPIKeyVerified = true;
                    return responseJson.RootElement.GetProperty("access_token").GetString() != null ? 1 : 0;
                }
            });

            return result; // if fail return 0
        }

        async private Task<int> getAccessTokenByRefreshToken()
        {
            Debug.WriteLine("Method called: getAccessTokenByRefreshToken");
            int result = await Task.Run(async () =>
            {
                // use the refresh token to get new access token and refresh token
                HttpClient client = new System.Net.Http.HttpClient();
                // setup request headers
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Accept", "application/json");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Content-Type", "application/x-www-form-urlencoded");
                // setup request body
                var values = new Dictionary<string, string>
                {
                    { "client_id", "43679" },
                    { "client_secret", Properties.Settings.Default.client_secret },
                    { "refresh_token", Properties.Settings.Default.refresh_token },
                    { "grant_type", "refresh_token" }
                };
                // convert to form url encoded content
                var content = new FormUrlEncodedContent(values);
                // send post request
                var AccessResponse = await client.PostAsync("https://osu.ppy.sh/oauth/token", content);
                //receive response
                var responseMessage = await AccessResponse.Content.ReadAsStringAsync();
                Debug.WriteLine("Access Token Response: " + responseMessage);
                // store the access token and refresh token in settings
                var responseJson = System.Text.Json.JsonDocument.Parse(responseMessage);
                Properties.Settings.Default.access_token = responseJson.RootElement.GetProperty("access_token").GetString();
                Properties.Settings.Default.refresh_token = responseJson.RootElement.GetProperty("refresh_token").GetString();
                Properties.Settings.Default.expires_in = System.DateTime.Now.AddSeconds(responseJson.RootElement.GetProperty("expires_in").GetInt32());
                // set isAPIKeyVerified as true
                Properties.Settings.Default.isAPIKeyVerified = true;
                return responseJson.RootElement.GetProperty("access_token").GetString() != null ? 1 : 0;
            });

            return result; // if fail return 0
        }
    }
}
