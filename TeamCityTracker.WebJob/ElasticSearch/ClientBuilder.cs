using System;
using System.Configuration;
using Nest;
using TeamCityTracker.WebJob.Model;

namespace TeamCityTracker.WebJob.ElasticSearch
{
    public class ClientBuilder : IClientBuilder
    {
        public ElasticClient GetClient()
        {
            var connectionSettings = ClientBuilder.CreateDefaulConnectionSettings();
            var client = new ElasticClient(connectionSettings);

            return client;
        }

        private static ConnectionSettings CreateDefaulConnectionSettings()
        {
            var appSettings = new AppSettingsReader();
            var uri = new Uri((string) appSettings.GetValue("ElasticSearch.Cluster.Url", typeof(string)));
            var connectionSettings = new ConnectionSettings(uri);

            connectionSettings.BasicAuthentication(
                (string)appSettings.GetValue("ElasticSearch.Username", typeof(string)),
                (string)appSettings.GetValue("ElasticSearch.Password", typeof(string))
            );

            connectionSettings.DefaultMappingFor<Build>(m => m.IndexName("build"));

            return connectionSettings;
        }
    }
}