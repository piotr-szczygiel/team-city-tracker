using System;
using System.Collections.Generic;
using System.Threading;
using Nest;
using TeamCityTracker.Common.ElasticSearch;
using TeamCityTracker.Common.Model;

namespace TeamCityTracker.WebJob.ElasticSearch
{
    public class BuildRepository : IBuildRepository
    {
        private readonly Nest.ElasticClient client;

        public BuildRepository(IClientBuilder clientBuilder)
        {
            this.client = clientBuilder.GetClient();
        }

        public void LoadData(IEnumerable<Build> builds)
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