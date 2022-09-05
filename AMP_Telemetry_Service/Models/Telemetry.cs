namespace AMP_Telemetry_Service.Models
{
    // TODO: Adjust/remove this!
    /// <summary>
    /// This object stores the required client-side metrics, as-is it is unused.
    /// </summary>
    public struct Telemetry
    {
        // From query params:
        // int framesize, [FromQuery] int[] bitratesAvailable, int bitrateSwitches, int bufferingEvents, float timeSpentBuffering
        public int FrameSize { get; set; }
        public HashSet<int> BitratesAvailable { get; set; }
        public int BitrateSwitches{ get; set; }
        public int BufferingEvents { get; set; }
        public float TimeSpentBuffering { get; set; }

    }
}