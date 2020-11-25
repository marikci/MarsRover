using MarsRover.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.States
{
    public class TurnLeftState : IState
    {
        IRover _rover;
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
