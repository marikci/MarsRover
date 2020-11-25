using MarsRover.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.States
{
    public class TurnRightState : IState
    {
        IRover _rover;
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
