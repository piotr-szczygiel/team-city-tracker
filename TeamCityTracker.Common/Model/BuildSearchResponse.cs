using System.Collections.Generic;

namespace TeamCityTracker.Common.Model
{
    public class BuildSearchResponse
    {
        public IEnumerable<BuildInfo> Builds { get; set; }
    }
}