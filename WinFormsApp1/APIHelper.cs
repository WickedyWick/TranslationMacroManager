using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using System.Configuration;
namespace WinFormsApp1
{
    public static class APIHelper
    { 
        private static readonly string route = "/translate?api-version=3.0&from={0}&to={1}";
        private static bool requestOngoing = false;
        public static async Task<string> Translate(string inputText)
        {
            if (requestOngoing)
                return string.Empty;
            try
            {
                requestOngoing = true;
                object[] body = new object[] { new { Text = inputText } };
                var requestBody = JsonConvert.SerializeObject(body);

                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage())
                {
                    client.Timeout = TimeSpan.FromSeconds(5);
                    request.Method = HttpMethod.Post;
                    string fullRoute = String.Format(route, Config.FromLangCode, Config.ToLangCode);
                    request.RequestUri = new Uri(Config.Endpoint + fullRoute);
                    request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                    request.Headers.Add("Ocp-Apim-Subscription-Key", Config.ApiKey);
                    request.Headers.Add("Ocp-Apim-Subscription-Region", Config.Location);

                    HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                    var result = await response.Content.ReadFromJsonAsync<TranslationDto[]>();

                    if (result is null)
                        return string.Empty;

                    if (result.Length == 0)
                        return string.Empty;

                    if (result[0].translations.Length == 0)
                        return string.Empty;

                    requestOngoing = false;
                    return result[0].translations[0].text;
                }
            }
            catch (Exception ex)
            {
                requestOngoing = false;
                return "";
            }
        }
    }
}
