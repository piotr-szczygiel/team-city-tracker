using Nest;

namespace TeamCityTracker.Common.Model
{
    [ElasticsearchType(Name = "build")]
    public class Build
    {
        [Number(Name = "id")]
        public int Id { get; set; }

        [Keyword(Name = "build_type_id")]
        public string BuildTypeId { get; set; }

        [Text(Name = "number")]
        public string Number { get; set; }

        [Keyword(Name = "status")]
        public string Status { get; set; }
    }
}