using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Barchart.MarketData.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Barchart.MarketData.Service
{
    public class Client : IDisposable
    {
        private readonly HttpClient _httpClient;
        private const string Url = "http://marketdata.websol.barchart.com/getHistory.json";

        public Client()
        {
            _httpClient = new HttpClient();
        }

        public Client(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<HistoryResponse> GetHistory(string urlSuffix)
        {
            var uri = new Uri(string.Concat(Url, urlSuffix));

            var response = await HttpGetAsync(uri);

            var jObject = JObject.Parse(response);
            var history = JsonConvert.DeserializeObject<HistoryResponse>(jObject.ToString());

            return history;
        }


        public async Task<string> HttpGetAsync(Uri uri)
        {
            HttpResponseMessage httpResponseMessage = null;

            try
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = uri,
                    Method = HttpMethod.Get
                };

                httpResponseMessage = await _httpClient.SendAsync(request).ConfigureAwait(false);
                httpResponseMessage.EnsureSuccessStatusCode();

                var response = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                return response;
            }
            catch (HttpRequestException)
            {
                if (httpResponseMessage == null) throw;

                switch (httpResponseMessage.StatusCode)
                {
                    case HttpStatusCode.Unauthorized:

                    case HttpStatusCode.BadRequest:

                    case HttpStatusCode.InternalServerError:

                    default:

                        throw;
                }
            }
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
