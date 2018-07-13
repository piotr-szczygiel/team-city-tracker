using System.Collections.Generic;
using System.Threading.Tasks;
using TeamCityTracker.Common.Model;

namespace TeamCityTracker.Common.ElasticSearch
{
    public interface IDataLoader
    {
        Task Load(IEnumerable<Build> builds);
    }
}