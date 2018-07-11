using System.Threading.Tasks;
using TeamCityTracker.WebJob.Model;

namespace TeamCityTracker.WebJob.ApiReader
{
    public interface IApiReader
    {
        Task<BuildsResponse> GetBuilds();
    }
}