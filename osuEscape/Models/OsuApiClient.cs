using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace osuEscape.Models
{
    public class OsuApiClient
    {
        private const int clientId = 43739;
        private const string responseType = "code";
        private const string scope = "public";
        private static readonly HttpClient s_httpClient = new();
        private const string redirectUri = "http://localhost:10010/";

        public OsuApiClient() { }

        public static async Task<JsonElement> GetUserInfoByUserNameAsync(string userName)
        {
            Debug.WriteLine("Method called: GetUserInfoByUserNameAsync");
            Debug.WriteLine("Access token: " + Properties.Settings.Default.access_token);

            using var request = new HttpRequestMessage(HttpMethod.Get, $"https://osu.ppy.sh/api/v2/users/@{userName}/");
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(Properties.Settings.Default.access_token))
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Properties.Settings.Default.access_token);
            }

            var response = await s_httpClient.SendAsync(request).ConfigureAwait(false);
            var responseMessage = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var responseJson = JsonDocument.Parse(responseMessage);
            return responseJson.RootElement;
        }

        public async Task<int> TryLoginAsync()
        {
            Debug.WriteLine("Method called: TryLoginAsync");

            if (string.IsNullOrEmpty(Properties.Settings.Default.access_token) || string.IsNullOrEmpty(Properties.Settings.Default.refresh_token))
            {
                return await GetAccessTokenByAuthAsync().ConfigureAwait(false);
            }

            if (Properties.Settings.Default.expires_in <= System.DateTime.Now && !string.IsNullOrEmpty(Properties.Settings.Default.refresh_token))
            {
                return await GetAccessTokenByRefreshTokenAsync().ConfigureAwait(false);
            }

            return 1;
        }

        private async Task<int> GetAccessTokenByAuthAsync()
        {
            Debug.WriteLine("Method called: GetAccessTokenByAuthAsync");

            var startInfo = new ProcessStartInfo
            {
                FileName = $"https://osu.ppy.sh/oauth/authorize?client_id={clientId}&response_type={responseType}&scope={scope}",
                UseShellExecute = true
            };

            Process.Start(startInfo);

            int result = await Task.Run(async () =>
            {
                using var listener = new System.Net.HttpListener();
                listener.Prefixes.Add(redirectUri);
                listener.Start();

                var context = await listener.GetContextAsync().ConfigureAwait(false);
                var request = context.Request;
                var response = context.Response;

                response.StatusCode = 200;
                response.OutputStream.Close();
                listener.Stop();
                var code = request.QueryString["code"];

                using var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var contents = new Dictionary<string, string>
                {
                    { "client_id", clientId.ToString() },
                    { "client_secret", Properties.Settings.Default.client_secret },
                    { "code", code },
                    { "grant_type", "authorization_code" }
                };

                var encodedContent = new FormUrlEncodedContent(contents);
                var accessResponse = await client.PostAsync("https://osu.ppy.sh/oauth/token", encodedContent).ConfigureAwait(false);
                var responseMessage = await accessResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                var responseJson = JsonDocument.Parse(responseMessage);
                if (!responseJson.RootElement.TryGetProperty("access_token", out var accessToken))
                {
                    Debug.WriteLine("OAuth response did not contain access_token. Raw response: " + responseMessage);
                    // Handle error, e.g., show message to user
                    return 0;
                }

                Properties.Settings.Default.access_token = accessToken.GetString();
                Properties.Settings.Default.refresh_token = responseJson.RootElement.GetProperty("refresh_token").GetString();
                Properties.Settings.Default.expires_in = System.DateTime.Now.AddSeconds(responseJson.RootElement.GetProperty("expires_in").GetInt32());
                Properties.Settings.Default.isOAuthVerified = true;

                return !string.IsNullOrEmpty(Properties.Settings.Default.access_token) ? 1 : 0;
            }).ConfigureAwait(false);

            return result;
        }

        private async Task<int> GetAccessTokenByRefreshTokenAsync()
        {
            Debug.WriteLine("Method called: GetAccessTokenByRefreshTokenAsync");

            return await Task.Run(async () =>
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var contents = new Dictionary<string, string>
                {
                    { "client_id", clientId.ToString() },
                    { "client_secret", Properties.Settings.Default.client_secret },
                    { "refresh_token", Properties.Settings.Default.refresh_token },
                    { "grant_type", "refresh_token" }
                };

                var encodedContent = new FormUrlEncodedContent(contents);
                var accessResponse = await client.PostAsync("https://osu.ppy.sh/oauth/token", encodedContent).ConfigureAwait(false);
                var responseMessage = await accessResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                var responseJson = JsonDocument.Parse(responseMessage);
                Properties.Settings.Default.access_token = responseJson.RootElement.GetProperty("access_token").GetString();
                Properties.Settings.Default.refresh_token = responseJson.RootElement.GetProperty("refresh_token").GetString();
                Properties.Settings.Default.expires_in = System.DateTime.Now.AddSeconds(responseJson.RootElement.GetProperty("expires_in").GetInt32());
                Properties.Settings.Default.isOAuthVerified = true;

                return !string.IsNullOrEmpty(Properties.Settings.Default.access_token) ? 1 : 0;
            }).ConfigureAwait(false);
        }
    }
}
