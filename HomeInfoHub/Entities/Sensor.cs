using System.ComponentModel.DataAnnotations;

namespace HomeInfoHub.Entities
{
    public class Sensor
    {
       public Guid Id { get; set; }
       public string SensorName { get; set; }
       public string Serialization { get; set; }

       public string SensorType { get; set; }

       public ICollection<Log> Logs { get; set; } = new List<Log>();
    }
}
