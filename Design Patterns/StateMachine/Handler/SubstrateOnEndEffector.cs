namespace Handler
{
    public class SubstrateOnEndEffector : IHandlerState
    {
        public string MoveToEndEffector() => "Substrate already here";
        public string MoveToFoup() => "Substrate move to foup";
        public string MoveToStage() => "Substrate move to stage";
    }
}