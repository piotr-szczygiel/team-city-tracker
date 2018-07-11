using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TeamCityTracker.WebJob.ApiReader.AuthorizationProvider;
using TeamCityTracker.WebJob.Model;

namespace TeamCityTracker.WebJob.ApiReader
{
    public class ApiReader : IApiReader
    {
        private readonly IAuthorizationProvider authorizationProvider;

        public string Uri { get; set; }

        public ApiReader(IAuthorizationProvider authorizationProvider)
        {
            this.authorizationProvider = authorizationProvider;
            var appSettings = new AppSettingsReader();
            var url = appSettings.GetValue("TeamCity.RestApi.Url", typeof(string));

            this.Uri = $"http://{url}/app/rest";
        }

        public async Task<BuildsResponse> GetBuilds()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = this.authorizationProvider.GetAuthenticationHeader();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync($"{this.Uri}/builds").ConfigureAwait(false);
                var content = response.Content;

                var result = await content.ReadAsStringAsync().ConfigureAwait(false);
                var jsonResponse = JsonConvert.DeserializeObject<BuildsResponse>(result);

                return jsonResponse;
            }
        }
    }
}