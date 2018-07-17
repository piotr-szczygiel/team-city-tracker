using System.Net.Http.Headers;
using NSubstitute;
using NUnit.Framework;
using TeamCityTracker.WebJob.AuthorizationProvider;

namespace TeamCityTracker.WebJob.Tests.HttpClientBuilder
{
    [TestFixture]
    public class HttpClientBuilderTest
    {
        [Test]
        public void ShouldGetClientWithCorrectRequestHeaders()
        {
            // Given
            var authorizationProvider = Substitute.For<IAuthorizationProvider>();
            var authenticationHeaderValue = new AuthenticationHeaderValue("Basic", "SomeKey");
            authorizationProvider.GetAuthenticationHeader().Returns(authenticationHeaderValue);
            var clientBuilder = new WebJob.HttpClientBuilder.HttpClientBuilder(authorizationProvider);

            // When
            var httpClient = clientBuilder.GetClient();

            // Then
            Assert.That(httpClient.DefaultRequestHeaders.Authorization, Is.EqualTo(authenticationHeaderValue));   
        }
    }
}
