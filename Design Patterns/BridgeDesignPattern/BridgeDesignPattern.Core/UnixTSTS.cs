namespace BridgeDesignPattern.Core
{
    public class UnixTSTS : TimeSlicedThreadScheduler
    {
        public override TimeSpan GetTimeSliceAmount()
        {
            return new TimeSpan(0, 0, 0, 0, 11);
        }

        public override string ThreadSchedulingWayName()
        {
            return "UnixTSTS";
        }
    }
}
