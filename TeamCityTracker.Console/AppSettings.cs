using System.Configuration;
using TeamCityTracker.Common.Credentials;

namespace TeamCityTracker.Console
{
    public class AppSettings : IElasticSearchCredentials
    {
        private static readonly AppSettingsReader AppSettingsReader = new AppSettingsReader();

        public string ElasticSearchUrl => (string)AppSettingsReader.GetValue("ElasticSearch.Cluster.Url", typeof(string));

        public string ElasticSearchUsername => (string)AppSettingsReader.GetValue("ElasticSearch.Username", typeof(string));

        public string ElasticSearchPassword => (string)AppSettingsReader.GetValue("ElasticSearch.Password", typeof(string));
    }
}