using System;

namespace Handler
{
    public class HandlerMachine : IHandlerState
    {
        public IHandlerState HandlerState { get; set; }

        public HandlerMachine()
        {
            HandlerState = new SubstrateOnFoup();
        }

        public string MoveToEndEffector()
        {
            var res = HandlerState.MoveToEndEffector();

            if (HandlerState is SubstrateOnFoup || HandlerState is SubstrateOnStage)
                HandlerState = new SubstrateOnEndEffector();

            return res;
        }

        public string MoveToFoup()
        {
            var res = HandlerState.MoveToFoup();

            if (HandlerState is SubstrateOnEndEffector)
                HandlerState = new SubstrateOnFoup();

            return res;
        }

        public string MoveToStage()
        {
            var res = HandlerState.MoveToStage();

            if (HandlerState is SubstrateOnEndEffector)
                HandlerState = new SubstrateOnStage();

            return res;
        }
    }
}