using MarsRover.Business.Interfaces;
using MarsRover.Models.Enums;  

namespace MarsRover.Business
{
    public class Position : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public EnDirections Direction { get; set; }

        public Position(int x=0, int y=0, EnDirections direction=EnDirections.E)
        {
            this.X = x;
            this.Y = y;
            this.Direction = direction;
        }
    }
}
