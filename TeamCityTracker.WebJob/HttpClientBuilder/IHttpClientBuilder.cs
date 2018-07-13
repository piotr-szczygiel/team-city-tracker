using System.Net.Http;

namespace TeamCityTracker.WebJob.HttpClientBuilder
{
    public interface IHttpClientBuilder
    {
        HttpClient GetClient();
    }
}