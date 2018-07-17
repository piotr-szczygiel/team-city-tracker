using NSubstitute;
using NUnit.Framework;
using TeamCityTracker.Common.Credentials;

namespace TeamCityTracker.WebJob.Tests.AuthorizationProvider
{
    [TestFixture]
    public class AuthorizationProviderTest
    {
        [Test, TestCaseSource(typeof(CredentialsTestCase), nameof(CredentialsTestCase.GetTestCases))]
        public void WhenCreatingAuthenticationHeaderValue_ShouldEncodeCredentials(CredentialsTestCase testCase)
        {
            // Given
            var teamCityCredentials = Substitute.For<ITeamCityCredentials>();
            teamCityCredentials.TeamCityUsername.Returns(testCase.Username);
            teamCityCredentials.TeamCityPassword.Returns(testCase.Password);
            var authorizationProvider = new WebJob.AuthorizationProvider.AuthorizationProvider(teamCityCredentials);

            // When
            var authenticationHeader = authorizationProvider.GetAuthenticationHeader();

            // Then
            Assert.That(authenticationHeader.Parameter, Is.EqualTo(testCase.Encoded));
        }
    }
}