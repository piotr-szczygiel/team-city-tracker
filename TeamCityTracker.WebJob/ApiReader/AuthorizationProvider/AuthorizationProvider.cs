using System;
using System.Configuration;
using System.Net.Http.Headers;
using System.Text;

namespace TeamCityTracker.WebJob.ApiReader.AuthorizationProvider
{
    public class AuthorizationProvider : IAuthorizationProvider
    {
        private readonly string username;
        private readonly string password;

        public AuthorizationProvider()
        {
            var appSettings = new AppSettingsReader();
            this.username = (string)appSettings.GetValue("TeamCity.RestApi.Username", typeof(string));
            this.password = (string)appSettings.GetValue("TeamCity.RestApi.Password", typeof(string));

        }
        public AuthenticationHeaderValue GetAuthenticationHeader()
        {
            var byteArray = Encoding.ASCII.GetBytes($"{this.username}:{this.password}");
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }
    }
}