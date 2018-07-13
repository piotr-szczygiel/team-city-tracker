using System.Threading.Tasks;
using TeamCityTracker.Common.Model;

namespace TeamCityTracker.WebJob.ApiReader
{
    public interface IApiReader
    {
        Task<BuildsResponse> GetBuilds();
    }
}