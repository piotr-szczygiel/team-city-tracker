using System;
using Nest;
using TeamCityTracker.Common.Credentials;
using TeamCityTracker.Common.Model;

namespace TeamCityTracker.Common.ElasticSearch
{
    public class ClientBuilder : IClientBuilder
    {
        private readonly IElasticSearchCredentials credentials;

        public ClientBuilder(IElasticSearchCredentials credentials)
        {
            this.credentials = credentials;
        }

        public ElasticClient GetClient()
        {
            var connectionSettings = this.CreateDefaulConnectionSettings();
            var client = new ElasticClient(connectionSettings);

            return client;
        }

        private ConnectionSettings CreateDefaulConnectionSettings()
        {
            var uri = new Uri(this.credentials.ElasticSearchUrl);
            var connectionSettings = new ConnectionSettings(uri);

            connectionSettings.BasicAuthentication(this.credentials.ElasticSearchUsername, this.credentials.ElasticSearchPassword);
            connectionSettings.DefaultMappingFor<Build>(m => m.IndexName("build"));

            return connectionSettings;
        }
    }
}