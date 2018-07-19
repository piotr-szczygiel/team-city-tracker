using System.Threading.Tasks;
using TeamCityTracker.WebJob.Model;

namespace TeamCityTracker.WebJob.TeamCityApiReader
{
    public interface ITeamCityApiReader
    {
        Task<BuildsResponse> GetBuilds();
    }
}