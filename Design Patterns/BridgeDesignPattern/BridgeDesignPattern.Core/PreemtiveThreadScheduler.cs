namespace BridgeDesignPattern.Core
{
    public abstract class PreemtiveThreadScheduler : ThreadScheduler
    {
        public abstract int GetPreemtiveThreadsAmount();
    }
}
