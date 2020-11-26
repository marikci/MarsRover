using MarsRover.Business.Interfaces;

namespace MarsRover.Business.States
{
    public class TurnLeftState : IState
    {
        private readonly IRover _rover;
        public TurnLeftState(IRover rover)
        {
            _rover = rover;
        }
        public void Handle()
        {
            _rover.TurnLeft();
        }
    }
}
