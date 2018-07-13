using System.Net.Http.Headers;

namespace TeamCityTracker.WebJob.AuthorizationProvider
{
    public interface IAuthorizationProvider
    {
        AuthenticationHeaderValue GetAuthenticationHeader();
    }
}
