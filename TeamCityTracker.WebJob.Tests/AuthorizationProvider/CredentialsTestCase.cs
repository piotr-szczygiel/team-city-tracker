using System;
using System.Collections.Generic;

namespace TeamCityTracker.WebJob.Tests.AuthorizationProvider
{
    public class CredentialsTestCase
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Encoded { get; set; }

        public static IEnumerable<CredentialsTestCase> GetTestCases()
        {
            return new[]
            {
                new CredentialsTestCase()
                {
                    Username = "John Travolta",
                    Password = "NzWASv7LuxM6ED2H",
                    Encoded = "Sm9obiBUcmF2b2x0YTpOeldBU3Y3THV4TTZFRDJI"
                },
                new CredentialsTestCase()
                {
                    Username = "Cristiano.Ronaldo",
                    Password = "nwu7LMr2k6QWYdKy",
                    Encoded = "Q3Jpc3RpYW5vLlJvbmFsZG86bnd1N0xNcjJrNlFXWWRLeQ=="
                }
            };
        }
    }
}