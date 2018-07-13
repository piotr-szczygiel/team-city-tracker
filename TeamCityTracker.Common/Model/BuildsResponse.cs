﻿using System.Collections.Generic;

namespace TeamCityTracker.Common.Model
{
    public class BuildsResponse
    {
        public int Count { get; set; }

        public string NextHref { get; set; }

        public List<Build> Build { get; set; }
    }
}