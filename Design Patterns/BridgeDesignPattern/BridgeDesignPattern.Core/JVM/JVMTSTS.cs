namespace BridgeDesignPattern.Core.JVM
{
    public class JVMTSTS : TimeSlicedThreadScheduler
    {
        public override TimeSpan GetTimeSliceAmount()
        {
            return new TimeSpan(0, 0, 0, 0, 3);
        }

        public override string ThreadSchedulingWayName()
        {
            return "JVMTSTS";
        }
    }
}
