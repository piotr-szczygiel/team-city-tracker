using System.Collections.Generic;
using System.Threading.Tasks;
using TeamCityTracker.Common.Model;

namespace TeamCityTracker.Common.ElasticSearch
{
    public class DataLoader : IDataLoader
    {
        private readonly IClientBuilder clientBuilder;

        public DataLoader(IClientBuilder clientBuilder)
        {
            this.clientBuilder = clientBuilder;
        }

        public async Task Load(IEnumerable<Build> builds)
        {
            var client = this.clientBuilder.GetClient();
            foreach (var build in builds)
            {
                var response = await client.IndexDocumentAsync(build).ConfigureAwait(false);
            }
        }
    }
}