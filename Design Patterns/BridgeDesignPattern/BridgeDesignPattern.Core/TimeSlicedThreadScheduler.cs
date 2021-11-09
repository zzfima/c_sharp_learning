namespace BridgeDesignPattern.Core
{
    public abstract class TimeSlicedThreadScheduler : ThreadScheduler
    {
        public abstract TimeSpan GetTimeSliceAmount();
    }
}
