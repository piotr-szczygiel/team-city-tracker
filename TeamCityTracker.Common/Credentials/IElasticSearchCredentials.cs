namespace TeamCityTracker.Common.Credentials
{
    public interface IElasticSearchCredentials
    {
        string ElasticSearchUrl { get; }

        string ElasticSearchUsername { get; }

        string ElasticSearchPassword { get; }
    }
}