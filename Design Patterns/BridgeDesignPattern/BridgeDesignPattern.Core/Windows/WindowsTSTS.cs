namespace BridgeDesignPattern.Core.Windows
{
    public class WindowsTSTS : TimeSlicedThreadScheduler
    {
        public override TimeSpan GetTimeSliceAmount()
        {
            return new TimeSpan(0, 0, 0, 0, 12);
        }

        public override string ThreadSchedulingWayName()
        {
            return "WindowsTSTS";
        }
    }
}
