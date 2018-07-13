using System;
using System.Net.Http.Headers;
using System.Text;
using TeamCityTracker.Common.Credentials;

namespace TeamCityTracker.WebJob.AuthorizationProvider
{
    public class AuthorizationProvider : IAuthorizationProvider
    {
        private readonly ITeamCityCredentials teamCityCredentials;

        public AuthorizationProvider(ITeamCityCredentials teamCityCredentials)
        {
            this.teamCityCredentials = teamCityCredentials;
        }

        public AuthenticationHeaderValue GetAuthenticationHeader()
        {
            var byteArray = Encoding.ASCII.GetBytes($"{this.teamCityCredentials.TeamCityUsername}:{this.teamCityCredentials.TeamCityPassword}");
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }
    }
}