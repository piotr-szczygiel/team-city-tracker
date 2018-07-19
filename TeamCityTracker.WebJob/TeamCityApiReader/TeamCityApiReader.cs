using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TeamCityTracker.Common.Credentials;
using TeamCityTracker.WebJob.HttpClientBuilder;
using TeamCityTracker.WebJob.Model;

namespace TeamCityTracker.WebJob.TeamCityApiReader
{
    public class TeamCityApiReader : ITeamCityApiReader
    {
        private readonly HttpClient client;

        public string Uri { get; set; }

        public TeamCityApiReader(IHttpClientBuilder clientBuilder, ITeamCityCredentials teamCityCredentials)
        {
            this.client = clientBuilder.GetClient();
            this.Uri = $"{teamCityCredentials.TeamCityApiUrl}/app/rest";
        }

        public async Task<BuildsResponse> GetBuilds()
        {
            var response = await this.client.GetAsync($"{this.Uri}/builds?locator=count:100").ConfigureAwait(false);
            var content = response.Content;

            var result = await content.ReadAsStringAsync().ConfigureAwait(false);
            var jsonResponse = JsonConvert.DeserializeObject<BuildsResponse>(result);

            return jsonResponse;
        }
    }
}