using FluentAssertions;
using Handler;
using Xunit;

namespace HandlerTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var handlerState = new SubstrateOnStage();
            handlerState.MoveToStage().Should().Be("Substrate already here");
        }


        [Fact]
        public void TestHandlerMachine()
        {
            var handlerMachine = new HandlerMachine();
            handlerMachine.HandlerState.GetType().Name.Should().Be("SubstrateOnFoup");

            handlerMachine.MoveToStage().Should().Be("Substrate can not move to stage");
            handlerMachine.MoveToFoup().Should().Be("Substrate already here");
            handlerMachine.MoveToEndEffector().Should().Be("Substrate move to end effector");
            handlerMachine.HandlerState.GetType().Name.Should().Be("SubstrateOnEndEffector");

            handlerMachine.MoveToStage().Should().Be("Substrate move to stage");
            handlerMachine.MoveToFoup().Should().Be("Substrate can not move to foup");
            handlerMachine.HandlerState.GetType().Name.Should().Be("SubstrateOnStage");

            handlerMachine.MoveToEndEffector().Should().Be("Substrate move to end effector");
            handlerMachine.MoveToEndEffector().Should().Be("Substrate already here");
            handlerMachine.HandlerState.GetType().Name.Should().Be("SubstrateOnEndEffector");

            handlerMachine.MoveToFoup().Should().Be("Substrate move to foup");
            handlerMachine.HandlerState.GetType().Name.Should().Be("SubstrateOnFoup");
        }
    }
}