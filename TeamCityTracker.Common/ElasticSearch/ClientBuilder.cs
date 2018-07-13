using System;
using System.Configuration;
using Nest;
using TeamCityTracker.Common.Model;

namespace TeamCityTracker.Common.ElasticSearch
{
    public class ClientBuilder : IClientBuilder
    {
        private readonly AppSettingsReader appSettingsReader;

        public ClientBuilder(AppSettingsReader appSettingsReader)
        {
            this.appSettingsReader = appSettingsReader;
        }

        public ElasticClient GetClient()
        {
            var connectionSettings = this.CreateDefaulConnectionSettings();
            var client = new ElasticClient(connectionSettings);

            return client;
        }

        private ConnectionSettings CreateDefaulConnectionSettings()
        {
            var uri = new Uri((string) this.appSettingsReader.GetValue("ElasticSearch.Cluster.Url", typeof(string)));
            var connectionSettings = new ConnectionSettings(uri);

            connectionSettings.BasicAuthentication(
                (string) this.appSettingsReader.GetValue("ElasticSearch.Username", typeof(string)),
                (string) this.appSettingsReader.GetValue("ElasticSearch.Password", typeof(string))
            );

            connectionSettings.DefaultMappingFor<Build>(m => m.IndexName("build"));

            return connectionSettings;
        }
    }
}