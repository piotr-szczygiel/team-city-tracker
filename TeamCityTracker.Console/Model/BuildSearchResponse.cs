using System.Collections.Generic;
using System.Linq;
using Nest;

namespace TeamCityTracker.Console.Model
{
    public class BuildSearchResponse
    {
        public IEnumerable<BuildInfo> Builds { get; set; }

        public static BuildSearchResponse Parse(IEnumerable<KeyedBucket<string>> buckets)
        {
            var buildSearchResponse = new BuildSearchResponse()
            {
                Builds = buckets.Select(item => new BuildInfo()
                {
                    BuildIdentifier = item.Key,
                    Executed = item.DocCount ?? 0,
                    Failed = item.Filter("failed").DocCount,
                    Succeed = item.Filter("succeed").DocCount,
                    FailurePercentage = item.BucketScript("failure_percentage").Value ?? 0
                })
            };
            return buildSearchResponse;
        }
    }
}