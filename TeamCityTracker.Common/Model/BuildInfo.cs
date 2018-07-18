using System;

namespace TeamCityTracker.Common.Model
{
    public class BuildInfo
    {
        public string BuildIdentifier { get; set; }

        public long TimesExecuted { get; set; }

        public long TimesFailed { get; set; }

        public long TimesSuccessed { get; set; }

        public double FailurePercentage => Math.Round(TimesFailed * 100.0 / TimesExecuted, 2);
    }
}