using System;
using System.Configuration;
using System.Net.Http.Headers;
using System.Text;

namespace TeamCityTracker.WebJob.AuthorizationProvider
{
    public class AuthorizationProvider : IAuthorizationProvider
    {
        private readonly string username;
        private readonly string password;

        public AuthorizationProvider(AppSettingsReader appSettingsReader)
        {
            this.username = (string) appSettingsReader.GetValue("TeamCity.RestApi.Username", typeof(string));
            this.password = (string) appSettingsReader.GetValue("TeamCity.RestApi.Password", typeof(string));

        }
        public AuthenticationHeaderValue GetAuthenticationHeader()
        {
            var byteArray = Encoding.ASCII.GetBytes($"{this.username}:{this.password}");
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }
    }
}