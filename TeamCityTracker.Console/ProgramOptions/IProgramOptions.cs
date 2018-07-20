using System.Collections.Generic;
using TeamCityTracker.Console.Model;

namespace TeamCityTracker.Console.ProgramOptions
{
    public interface IProgramOptions
    {
        IEnumerable<ProgramOption> GetOptions();
    }
}