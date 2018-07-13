using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TeamCityTracker.Common.Credentials;
using TeamCityTracker.Common.Model;
using TeamCityTracker.WebJob.HttpClientBuilder;

namespace TeamCityTracker.WebJob.ApiReader
{
    public class ApiReader : IApiReader
    {
        private readonly HttpClient client;

        public string Uri { get; set; }

        public ApiReader(IHttpClientBuilder clientBuilder, ITeamCityCredentials teamCityCredentials)
        {
            this.client = clientBuilder.GetClient();
            this.Uri = $"{teamCityCredentials.TeamCityApiUrl}/app/rest";
        }

        public async Task<BuildsResponse> GetBuilds()
        {
            var response = await this.client.GetAsync($"{this.Uri}/builds?locator=count:1000").ConfigureAwait(false);
            var content = response.Content;

            var result = await content.ReadAsStringAsync().ConfigureAwait(false);
            var jsonResponse = JsonConvert.DeserializeObject<BuildsResponse>(result);

            return jsonResponse;
        }
    }
}