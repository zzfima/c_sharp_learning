namespace Handler
{
    public class SubstrateOnFoup : IHandlerState
    {
        public string MoveToEndEffector() => "Substrate move to end effector";
        public string MoveToFoup() => "Substrate already here";
        public string MoveToStage() => "Substrate can not move to stage";
    }
}