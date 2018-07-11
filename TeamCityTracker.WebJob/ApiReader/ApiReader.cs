using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace TeamCityTracker.WebJob.ApiReader
{
    public class ApiReader : IApiReader
    {
        public string Uri { get; set; }

        private const int NumberOfItems = 300;

        public ApiReader()
        {
            var appSettings = new AppSettingsReader();
            var url = appSettings.GetValue("TeamCity.RestApi.Url", typeof(string));
            var username = appSettings.GetValue("TeamCity.RestApi.Username", typeof(string));
            var password = appSettings.GetValue("TeamCity.RestApi.Password", typeof(string));

            this.Uri = $"https://{username}:{password}@{url}";
        }

        public async Task<string> GetBuilds()
        {
            using (var client = new HttpClient())
            using (var response = await client.GetAsync(this.Uri).ConfigureAwait(false))
            using (var content = response.Content)
            {
                var result = await content.ReadAsStringAsync();
                return result;
            }
        }
    }
}