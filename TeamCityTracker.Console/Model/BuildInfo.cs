using System;

namespace TeamCityTracker.Common.Model
{
    public class BuildInfo
    {
        public string BuildIdentifier { get; set; }

        public long Executed { get; set; }

        public long Failed { get; set; }

        public long Succeed { get; set; }

        public double FailurePercentage { get; set; }
    }
}