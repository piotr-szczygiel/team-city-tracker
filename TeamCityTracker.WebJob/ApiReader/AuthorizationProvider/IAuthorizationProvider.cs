using System.Net.Http.Headers;

namespace TeamCityTracker.WebJob.ApiReader.AuthorizationProvider
{
    public interface IAuthorizationProvider
    {
        AuthenticationHeaderValue GetAuthenticationHeader();
    }
}
