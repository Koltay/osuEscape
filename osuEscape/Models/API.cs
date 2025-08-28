using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osuEscape.Models
{
    internal class API
    {
        //! IMPORTANT currently class was called by SettingsForm.cs->btnAuthorize_Click
        // develop a oauth application
        // reference: https://osu.ppy.sh/docs/index.html#authentication
        // first we need user to login on the website and authorize our application
        // respone: authorization code                                                  <-- Current progress
        // then we can use the authorization code to get access token and refresh token
        // respone: access token, refresh token, expires in xxx
        // we can use the access token to get user data and upload score

        private string REDIRECT_URI = "http://localhost:10010/"; // Same as website redirect_uri
        public API() { }
        public void authorize()
        {
            // open a web browser to let user login and authorize our application
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://osu.ppy.sh/oauth/authorize?client_id=43679&response_type=code&scope=public",
                UseShellExecute = true
            });

            // we need to get the code from the url, then we can use the code to get access token and refresh token
            Task.Run(() =>
            {
                using (var listener = new System.Net.HttpListener())
                {
                    listener.Prefixes.Add(REDIRECT_URI);
                    listener.Start();
                    var context = listener.GetContext();
                    var request = context.Request;
                    var response = context.Response;
                    var code = request.QueryString["code"];
                    //dump all the stuff
                    if (!string.IsNullOrEmpty(code))
                    {
                        Debug.WriteLine("Authorization code: " + code); //Temporarily print the code to console
                    }
                    var responseString = "<html><body>You can close this window now.</body></html>";
                    var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                    response.ContentLength64 = buffer.Length;
                    var output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    output.Close();
                }
            });
        }
    }
}
