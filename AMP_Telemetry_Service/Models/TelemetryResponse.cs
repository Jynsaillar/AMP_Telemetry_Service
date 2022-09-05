namespace AMP_Telemetry_Service.Models
{
    // Struct = stack allocation, Class = heap allocation -> garbage collected
    public struct TelemetryResponse
    {
        public bool HIGHEST_BITRATE_POSSIBLE { get; set; }
        public bool TOO_MANY_BITRATE_SWITCHES { get; set; }
        public bool TOO_MANY_BUFFERING { get; set; }
    }
}