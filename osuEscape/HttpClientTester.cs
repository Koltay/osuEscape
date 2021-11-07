using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace osuEscape
{
    public class HttpClientTester    
    {
        private static HttpClient client = new HttpClient();

        static void ShowBeatmap(Beatmap beatmap)
        {
            MessageBox.Show($"Max Combo: {beatmap.max_combo}");
        }

        static async Task<Beatmap> GetBeatmapAsync(string path)
        {
            Beatmap beatmap = null;

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                beatmap = await response.Content.ReadAsAsync<Beatmap>();
            }

            return beatmap;
        }

        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        // client side uploads to api
        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                //-k: api key
                //-b: beatmap_id


                // Get recent beatmap id from _reader

                var url = $"https://osu.ppy.sh/api/get_beatmaps?k=";

                // Get the beatmap
                Beatmap beatmap = await GetBeatmapAsync(url);
                ShowBeatmap(beatmap);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
