using System.Collections.Generic;

namespace MarsRover.Business.Interfaces
{
    public interface IRover
    {
        IPlateau Plateau { get; set; }
        IPosition Position { get; set; }
        List<IState> States { get; set; }
        void Move();
        bool SetPositions(string positions);
        bool SetMovements(string movements);
        void TurnLeft();
        void TurnRight();
    }
}