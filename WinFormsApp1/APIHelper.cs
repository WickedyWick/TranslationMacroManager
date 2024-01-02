﻿using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using System.Configuration;
namespace WinFormsApp1
{
    public static class APIHelper
    {
        private static Config _cfg;
        static APIHelper()
        {
            _cfg = ConfigLoader.LoadConfig();
        }
        
        
        private static readonly string route = "/translate?api-version=3.0&from=en&to=zh-Hant";
        private static bool requestOngoing = false;
        public static async Task<string> Translate(string inputText)
        {
            if (requestOngoing)
                return string.Empty;
            
            requestOngoing = true;
            object[] body = new object[] { new { Text = inputText } };
            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                client.Timeout = TimeSpan.FromSeconds(20);
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(_cfg.Endpoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", _cfg.ApiKey);
                request.Headers.Add("Ocp-Apim-Subscription-Region", _cfg.Location);

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
    }
}
