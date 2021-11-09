namespace BridgeDesignPattern.Core.JVM
{
    public class JVMPTS : PreemtiveThreadScheduler
    {
        public override int GetPreemtiveThreadsAmount()
        {
            return 6;
        }

        public override string ThreadSchedulingWayName()
        {
            return "JVMPTS";
        }
    }
}
