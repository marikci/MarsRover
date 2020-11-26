namespace MarsRover.Business.Interfaces
{
    public interface IMovements
    {
        IPosition Move(IPosition position);
        IPosition TurnLeft(IPosition position);
        IPosition TurnRight(IPosition position);
    }
}