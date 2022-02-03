namespace HomeInfoHub.Entities
{
    public class Log
    {
        public Guid Id { get; set; }

        public string Data { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public Guid SensorId { get; set; }
    }
}
