using System.Configuration;
using TeamCityTracker.Common.Credentials;

namespace TeamCityTracker.WebJob
{
    public class AppSettings : ITeamCityCredentials, IElasticSearchCredentials
    {
        private static readonly AppSettingsReader AppSettingsReader = new AppSettingsReader();

        public string TeamCityApiUrl => (string)AppSettingsReader.GetValue("TeamCity.RestApi.Url", typeof(string));

        public string TeamCityUsername => (string)AppSettingsReader.GetValue("TeamCity.RestApi.Username", typeof(string));

        public string TeamCityPassword => (string)AppSettingsReader.GetValue("TeamCity.RestApi.Password", typeof(string));

        public string ElasticSearchUrl => (string)AppSettingsReader.GetValue("ElasticSearch.Cluster.Url", typeof(string));

        public string ElasticSearchUsername => (string)AppSettingsReader.GetValue("ElasticSearch.Username", typeof(string));

        public string ElasticSearchPassword => (string)AppSettingsReader.GetValue("ElasticSearch.Password", typeof(string));
    }
}