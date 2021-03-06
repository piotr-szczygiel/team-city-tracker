﻿using TeamCityTracker.Common.ElasticSearch;
using TeamCityTracker.Common.Model;
using TeamCityTracker.Console.Model;

namespace TeamCityTracker.Console.ElasticSearch
{
    public class BuildRepository : IBuildRepository
    {
        private readonly Nest.ElasticClient client;

        public BuildRepository(IClientBuilder clientBuilder)
        {
            this.client = clientBuilder.GetClient();
        }

        public BuildSearchResponse GetMostFailingBuilds()
        {
            var searchResponse = client.Search<Build>(search => search
                .Aggregations(a => a
                    .Terms("count_build_type", t => t
                        .Field(fi => fi.BuildTypeId)
                        .Order(b => b.Descending("failed.doc_count"))
                        .Aggregations(a1 => a1
                            .Filter("failed", failure => failure
                                .Filter(f => f.Term(build => build.Status, Status.Failure))
                            )
                            .Filter("succeed", success => success
                                .Filter(f => f.Term(build => build.Status, Status.Success))
                            )
                            .BucketScript("failure_percentage", fp => fp
                                .BucketsPath(bp => bp
                                    .Add("failed_count", "failed._count")
                                    .Add("succeed_count", "succeed._count")
                                )
                                .Script(s => s.Source("params.failed_count * 100 / (params.failed_count + params.succeed_count)"))
                            )
                        )
                        .Size(30)
                    )
                )
            );

            return BuildSearchResponse.Parse(searchResponse.Aggregations.Terms("count_build_type").Buckets);
        }
    }
}