using MarsRover.Models.Enums;

namespace MarsRover.Business.Interfaces
{
    public interface IPosition
    {
        EnDirections Direction { get; set; }
        int X { get; set; }
        int Y { get; set; }
    }
}