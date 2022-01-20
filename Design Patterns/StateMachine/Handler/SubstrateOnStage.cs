namespace Handler
{
    public class SubstrateOnStage : IHandlerState
    {
        public string MoveToEndEffector() => "Substrate move to end effector";
        public string MoveToFoup() => "Substrate can not move to foup";
        public string MoveToStage() => "Substrate already here";
    }
}