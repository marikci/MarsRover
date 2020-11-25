namespace MarsRover.Business.Interfaces
{
    public interface IMovements
    {
        Position Move(Position position);
        Position TurnLeft(Position position);
        Position TurnRight(Position position);
    }
}