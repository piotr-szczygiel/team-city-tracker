using NSubstitute;
using NUnit.Framework;
using TeamCityTracker.Common.Credentials;
using TeamCityTracker.WebJob.HttpClientBuilder;

namespace TeamCityTracker.WebJob.Tests.ApiReader
{
    [TestFixture]
    public class ApiReaderTest
    {
        [Test]
        public void ShouldHaveCorrectApiUrl()
        {
            // Given
            var testUrl = "http://some.test.url";
            var teamCityCredentials = Substitute.For<ITeamCityCredentials>();
            teamCityCredentials.TeamCityApiUrl.Returns(testUrl);

            // When
            var apiReader = new WebJob.ApiReader.ApiReader(Substitute.For<IHttpClientBuilder>(), teamCityCredentials);

            // Then
            StringAssert.StartsWith(testUrl, apiReader.Uri);
            StringAssert.EndsWith("/app/rest", apiReader.Uri);
        }
    }
}
