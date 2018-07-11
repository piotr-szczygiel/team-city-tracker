using System.Threading.Tasks;

namespace TeamCityTracker.WebJob.ApiReader
{
    public interface IApiReader
    {
        Task<string> GetBuilds();
    }
}