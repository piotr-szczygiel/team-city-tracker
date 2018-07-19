using System.Collections.Generic;
using TeamCityTracker.Common.Model;

namespace TeamCityTracker.WebJob.ElasticSearch
{
    public interface IBuildRepository
    {
        void LoadData(IEnumerable<Build> builds);
    }
}