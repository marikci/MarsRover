using MarsRover.Business.Interfaces;
using MarsRover.Models.Enums;

namespace MarsRover.Business
{
    public class Movements: IMovements
    {
        public IPosition Move(IPosition position)
        {
            var currentPosition = position;
            switch (position.Direction)
            {
                case EnDirections.E:
                    currentPosition = new Position(position.X + 1, position.Y, position.Direction);
                    break;
                case EnDirections.W:
                    currentPosition = new Position(position.X - 1, position.Y, position.Direction);
                    break;
                case EnDirections.N:
                    currentPosition = new Position(position.X, position.Y + 1, position.Direction);
                    break;
                case EnDirections.S:
                    currentPosition = new Position(position.X, position.Y - 1, position.Direction);
                    break;
            }
            return currentPosition;
        }

        public IPosition TurnLeft(IPosition position)
        {
            var currentPosition = position;
            switch (position.Direction)
            {
                case EnDirections.E:
                    currentPosition = new Position(position.X, position.Y, EnDirections.N);
                    break;
                case EnDirections.W:
                    currentPosition = new Position(position.X, position.Y, EnDirections.S);
                    break;
                case EnDirections.N:
                    currentPosition = new Position(position.X, position.Y, EnDirections.W);
                    break;
                case EnDirections.S:
                    currentPosition = new Position(position.X, position.Y, EnDirections.E);
                    break;
            }
            return currentPosition;
        }

        public IPosition TurnRight(IPosition position)
        {
            var currentPosition = position;
            switch (position.Direction)
            {
                case EnDirections.E:
                    currentPosition = new Position(position.X, position.Y, EnDirections.S);
                    break;
                case EnDirections.W:
                    currentPosition = new Position(position.X, position.Y, EnDirections.N);
                    break;
                case EnDirections.N:
                    currentPosition = new Position(position.X, position.Y, EnDirections.E);
                    break;
                case EnDirections.S:
                    currentPosition = new Position(position.X, position.Y, EnDirections.W);
                    break;
            }
            return currentPosition;
        }

    }
}
