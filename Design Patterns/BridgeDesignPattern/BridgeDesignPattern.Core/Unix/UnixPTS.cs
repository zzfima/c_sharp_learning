namespace BridgeDesignPattern.Core.Unix
{
    public class UnixPTS : PreemtiveThreadScheduler
    {
        public override int GetPreemtiveThreadsAmount()
        {
            return 3;
        }

        public override string ThreadSchedulingWayName()
        {
            return "UnixPTS";
        }
    }
}
