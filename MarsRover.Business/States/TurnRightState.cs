using MarsRover.Business.Interfaces;

namespace MarsRover.Business.States
{
    public class TurnRightState : IState
    {
        private readonly IRover _rover;
        public TurnRightState(IRover rover)
        {
            _rover = rover;
        }
        public void Handle()
        {
            _rover.TurnRight();
        }
    }
}
