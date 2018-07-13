using System.Collections.Generic;
using TeamCityTracker.Common.Model;

namespace TeamCityTracker.Common.ElasticSearch
{
    public interface IDataLoader
    {
        void Load(IEnumerable<Build> builds);
    }
}