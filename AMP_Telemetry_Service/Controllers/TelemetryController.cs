using AMP_Telemetry_Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace AMP_Telemetry_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TelemetryController : ControllerBase
    {
        private readonly ILogger<TelemetryController> _logger;

        public TelemetryController(ILogger<TelemetryController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTelemetry")]
        public Telemetry Get()
        {
            var telemetry = new Telemetry()
            {

            };
            return telemetry;
        }

        [HttpPost(Name = "GetTelemetryFull")]
        public IActionResult Telemetry(int framesize, [FromQuery] int[] bitratesAvailable, int bitrateSwitches, int bufferingEvents, float timeSpentBuffering)
        {
            var telemetry = new Telemetry()
            {
                TOO_MANY_BUFFERING = (bufferingEvents > 5),
                HIGHEST_BITRATE_POSSIBLE = (framesize == bitratesAvailable.Max()),
                TOO_MANY_BITRATE_SWITCHES = (bitrateSwitches > 10)
            };
            return Ok(telemetry);
        }
    }
}
