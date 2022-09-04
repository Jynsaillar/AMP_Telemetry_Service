using AMP_Telemetry_Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace AMP_Telemetry_Service.Controllers
{
    /// <summary>
    /// This controller handles the routing for the telemetry API, specifically the calculation of the indices 
    /// </summary>
    [ApiController]
    [Route("[controller]")] // This is a placeholder, for this specific controller (TelementryController), the route would be truncated to https://<url>:<port>/telemetry/.
    public class TelemetryResponseController : ControllerBase
    {
        private readonly ILogger<TelemetryResponseController> _logger;

        public TelemetryResponseController(ILogger<TelemetryResponseController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "TelemetryResponse")] // Just an identifier to tell methods of same name apart.
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TelemetryResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // [FromQuery] is needed here to specify that this is an array type built from multiple same-named query parameters,
        // e.g. /../telemetry?bitratesAvailable=1080&bitratesAvailable=720
        // To 'build' this array in C#, the whole set of available bitrates is supplied via query string as single values one-by-one, like shown above.
        public IActionResult TelemetryResponse(
            int framesize, // Player frame size
            int bitrateSelected, // Player selected bitrate
            [FromQuery] int[] bitratesAvailable, // Bitrates available
            int bitrateSwitches, // Per 10s
            int shortBufferingEvents, // Buffering longer than 500ms, shorter than 1s
            int longBufferingEvents) // Buffering >= 1s
        {
            // Using local functions here to calculate the indices, since these functions will not be used outside of this method.

            // Calculates if any buffering events longer than 1s occured per 30s,
            // and if buffering events longer than 500ms occured more often than 3 times in 30s  (intervals are checked client side).
            static bool TooManyBufferingEvents(int shortBufferingEvents /* buffering >= 500 ms && <= 1000ms */, int longBufferingEvents /* buffering > 1000ms */) 
            {
                if (shortBufferingEvents >= 3 || longBufferingEvents >= 1)
                    return true;

                return false;
            }

            static bool HighestBitrateAvailableSelected()
            {
                // TODO: Some magic calculation to relate player frame size : selected player bitrate : available bitrates.
                // if (*magic goes here*)
                //    return true;

                return false;
            }

            // Calculates if the bitrate switches more than 2 times every 10 seconds (the 10 seconds interval is tested/provided by client side code).
            static bool TooManyBitrateSwitches(int bitrateSwitches /* Per 10s */)
            {
                if (bitrateSwitches > 2)
                    return true;

                return false;
            }

            var telemetryResponse = new TelemetryResponse()
            {
                TOO_MANY_BUFFERING = TooManyBufferingEvents(shortBufferingEvents, longBufferingEvents),
                HIGHEST_BITRATE_POSSIBLE = HighestBitrateAvailableSelected(),
                TOO_MANY_BITRATE_SWITCHES = TooManyBitrateSwitches(bitrateSwitches)
            };
            return new OkObjectResult(telemetryResponse); // TODO: Not 100% sure if OK(telemetryResponse) or OkObjectResult(telemetryResponse) is appropriate here, both work.
        }
    }
}
