using MarsRover.Business.Interfaces;

namespace MarsRover.Business.States
{
    public class MoveState : IState
    {
        private readonly IRover _rover;
        public MoveState(IRover rover)
        {
            _rover = rover;
        }
        public void Handle()
        {
            _rover.Move();
        }
    }
}
