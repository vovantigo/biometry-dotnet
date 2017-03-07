using PipServices.Commons.Data;

namespace PipServices.Telemetry.Models
{
    public sealed class Person: IStringIdentifiable
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
