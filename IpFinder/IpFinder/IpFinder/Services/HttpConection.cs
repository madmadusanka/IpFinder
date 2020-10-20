using IpFinder.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(HttpConection))]
namespace IpFinder.Services
{
    public class HttpConection
    {

        public async Task<T> GetAsync<T>(string url)
        {
            T result = default;

            try
            {
                HttpClient httpClient = await CreateHttpClient();
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<T>(
                     responseData,
                     new JsonSerializerSettings()
                     {
                         ContractResolver = new CamelCasePropertyNamesContractResolver()
                     });
                }

                else
                {
                    Exception ex = new Exception(response.StatusCode.ToString());
                    throw ex;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        private async Task<HttpClient> CreateHttpClient()
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();

            HttpClient httpClient = new HttpClient(httpClientHandler);

            return httpClient;
        }

    }
}
