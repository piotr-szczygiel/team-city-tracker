using System.Collections.Generic;
using System.Threading.Tasks;
using TeamCityTracker.WebJob.Model;

namespace TeamCityTracker.WebJob.ElasticSearch
{
    public interface IDataLoader
    {
        Task Load(IEnumerable<Build> builds);
    }
}