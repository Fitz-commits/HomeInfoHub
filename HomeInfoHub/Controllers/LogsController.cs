using AutoMapper;
using HomeInfoHub.DTO;
using HomeInfoHub.Entities;
using HomeInfoHub.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeInfoHub.Controllers
{
    [Route("api/sensors/{sensorId}/logs")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public LogsController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetLogs(Guid sensorId)
        {
            var logs = _context.Logs.Where(x => x.SensorId == sensorId);
            if (!logs.Any())
                return NotFound();
            var logList = await logs.ToListAsync();
            // Might want to map to DTO's
            return Ok(logList);
        }
        [HttpGet("{logId}",Name = "GetLog")]
        public async Task<IActionResult> GetLog(Guid sensorId, Guid logId)
        {
           var log = await _context.Logs.Where(x => x.SensorId == sensorId && x.Id == logId).FirstOrDefaultAsync();
           if (log == null)
                return NotFound();
           // Might want to map to DTO's
           return Ok(log);
        }
        [HttpPost]
        public async Task<IActionResult> AddLog([FromRoute] Guid sensorId,[FromBody]LogForCreationDto logForCreation)
        {
            var log = _mapper.Map<Log>(logForCreation);
            var sensor = await _context.Sensors.FindAsync(sensorId);
            if (sensor == null)
                return BadRequest();
            log.SensorId = sensorId;

            _context.Logs.Add(log);
            _context.SaveChanges();
            return CreatedAtRoute("GetLog", new { sensorId, logId = log.Id}, log);
        }

    }
}
