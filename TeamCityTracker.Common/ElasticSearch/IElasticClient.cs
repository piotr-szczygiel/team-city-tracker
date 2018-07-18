using System.Collections.Generic;
using Nest;
using TeamCityTracker.Common.Model;

namespace TeamCityTracker.Common.ElasticSearch
{
    public interface IElasticClient
    {
        void LoadData(IEnumerable<Build> builds);

        BuildSearchResponse GetMostFailingBuilds();
    }
}