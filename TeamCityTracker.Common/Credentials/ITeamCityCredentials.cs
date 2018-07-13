namespace TeamCityTracker.Common.Credentials
{
    public interface ITeamCityCredentials
    {
        string TeamCityApiUrl { get; }

        string TeamCityUsername { get; }

        string TeamCityPassword { get; }
    }
}