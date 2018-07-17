using System;
using System.Collections.Generic;
using System.Threading;
using Nest;
using TeamCityTracker.Common.Model;

namespace TeamCityTracker.Common.ElasticSearch
{
    public class DataLoader : IDataLoader
    {
        private readonly ElasticClient client;

        public DataLoader(IClientBuilder clientBuilder)
        {
            this.client = clientBuilder.GetClient();
        }

        public void Load(IEnumerable<Build> builds)
        {
            var waitHandle = new CountdownEvent(1);
            var bulkAll = client.BulkAll(builds, b => b
                .Index<Build>()
                .BackOffRetries(2)
                .BackOffTime("30s")
                .MaxDegreeOfParallelism(4)
                .Size(1000)
            );

            bulkAll.Subscribe(new BulkAllObserver(
                onNext: (b) => { Console.Write("."); },
                onError: (e) => throw e,
                onCompleted: () => waitHandle.Signal()
            ));
        }
    }
}