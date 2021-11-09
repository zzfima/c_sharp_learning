namespace BridgeDesignPattern.Core
{
    public class WindowsPTS : PreemtiveThreadScheduler
    {
        public override int GetPreemtiveThreadsAmount()
        {
            return 4;
        }

        public override string ThreadSchedulingWayName()
        {
            return "WindowsPTS";
        }
    }
}
