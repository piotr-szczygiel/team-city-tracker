namespace TeamCityTracker.WebJob.Model
{
    public class Build
    {
        public int Id { get; set; }

        public string BuildTypeId { get; set; }

        public string Number { get; set; }

        public string Status { get; set; }
    }
}