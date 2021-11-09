namespace ThreadScheduling.Core
{
    public abstract class TimeSlicedThreadScheduler : ThreadScheduler
    {
        public abstract TimeSpan GetTimeSliceAmount();
    }
}
