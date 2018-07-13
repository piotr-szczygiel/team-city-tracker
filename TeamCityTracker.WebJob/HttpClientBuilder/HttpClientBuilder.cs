using System.Net.Http;
using System.Net.Http.Headers;
using TeamCityTracker.WebJob.AuthorizationProvider;

namespace TeamCityTracker.WebJob.HttpClientBuilder
{
    public class HttpClientBuilder : IHttpClientBuilder
    {
        private readonly IAuthorizationProvider authorizationProvider;
        public static HttpClient Client;

        public HttpClientBuilder(IAuthorizationProvider authorizationProvider)
        {
            this.authorizationProvider = authorizationProvider;
        }

        public HttpClient GetClient()
        {
            if (HttpClientBuilder.Client != null)
            {
                return HttpClientBuilder.Client;
            }

            HttpClientBuilder.Client = new HttpClient();
            HttpClientBuilder.Client.DefaultRequestHeaders.Authorization = this.authorizationProvider.GetAuthenticationHeader();
            HttpClientBuilder.Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return HttpClientBuilder.Client;
        }
    }
}