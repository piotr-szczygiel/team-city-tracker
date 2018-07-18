using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Nest;
using TeamCityTracker.Common.Model;

namespace TeamCityTracker.Common.ElasticSearch
{
    public class ElasticClient : IElasticClient
    {
        private readonly Nest.ElasticClient client;

        public ElasticClient(IClientBuilder clientBuilder)
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

        public BuildSearchResponse GetMostFailingBuilds()
        {
            var searchResponse = client.Search<Build>(s => s
                .Aggregations(a => a
                    .Terms("count_build_type", t => t
                        .Field(fi => fi.BuildTypeId)
                        .Aggregations(a1 => a1.Terms("count_status", t1 => t1
                            .Field(fi1 => fi1.Status)
                        ))
                        .Size(10)   
                    )
                    .BucketSort("test-sort", d => d.Sort(b => b.Descending("status")))
                )
            );

            var buildSearchResponse = new BuildSearchResponse()
            {
                Builds = searchResponse.Aggregations.Terms("count_build_type").Buckets.Select(item =>
                {
                    var statuses = item.Terms("count_status").Buckets;
                    return new BuildInfo()
                    {
                        BuildIdentifier = item.Key,
                        TimesExecuted = item.DocCount ?? 0,
                        TimesFailed = statuses.FirstOrDefault(s => s.Key == Model.Status.Failure)?.DocCount ?? 0,
                        TimesSuccessed = statuses.FirstOrDefault(s => s.Key == Model.Status.Success)?.DocCount ?? 0
                    };
                })
            };
            return buildSearchResponse;
        }
    }
}