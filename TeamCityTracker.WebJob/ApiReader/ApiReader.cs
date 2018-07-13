using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TeamCityTracker.Common.Model;
using TeamCityTracker.WebJob.HttpClientBuilder;

namespace TeamCityTracker.WebJob.ApiReader
{
    public class ApiReader : IApiReader
    {
        private readonly HttpClient client;

        public string Uri { get; set; }

        public ApiReader(IHttpClientBuilder clientBuilder, AppSettingsReader appSettingsReader)
        {
            this.client = clientBuilder.GetClient();

            var url = appSettingsReader.GetValue("TeamCity.RestApi.Url", typeof(string));
            this.Uri = $"{url}/app/rest";
        }

        public async Task<BuildsResponse> GetBuilds()
        {
            var response = await this.client.GetAsync($"{this.Uri}/builds?locator=count:50").ConfigureAwait(false);
            var content = response.Content;

            var result = await content.ReadAsStringAsync().ConfigureAwait(false);
            var jsonResponse = JsonConvert.DeserializeObject<BuildsResponse>(result);

            return jsonResponse;
        }
    }
}