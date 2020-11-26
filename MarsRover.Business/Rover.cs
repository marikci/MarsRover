using MarsRover.Business.Interfaces;
using MarsRover.Business.States;
using MarsRover.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Business
{
    public class Rover : IRover
    {
        public IPosition Position { get; set; }
        public IPlateau Plateau { get; set; }
        public List<IState> States { get; set; }
        private readonly IMovements _movements;

        public Rover(IPosition position, IPlateau plateau, IMovements movements)
        {
            Position = position;
            Plateau = plateau;
            States = new List<IState>();
            _movements = movements;
        }

        public Rover()
        {
            States = new List<IState>();
        }
        public void Move()
        {
            Position = _movements.Move(Position);
            CheckOverflowPosition();
        }

        public void TurnLeft()
        {
            Position = _movements.TurnLeft(Position);
        }

        public void TurnRight()
        {
            Position = _movements.TurnRight(Position);
        }

        public bool SetPositions(string positions)
        {
            if (string.IsNullOrEmpty(positions))
            {
                return false;
            }
            var coordinates = positions.Split(' ');

            if (coordinates.Length != 3)
            {
                return false;
            }

            var isValidXCoordinate = int.TryParse(coordinates[0], out _);
            var isValidYCoordinate = int.TryParse(coordinates[1], out _);
            var isDirectionOk = Enum.IsDefined(typeof(EnDirections), coordinates[2]);

            if (!isValidXCoordinate || !isValidYCoordinate || !isDirectionOk)
            {
                return false;
            }

            Position.X = int.Parse(coordinates[0]);
            Position.Y = int.Parse(coordinates[1]);
            Position.Direction = (EnDirections)Enum.Parse(typeof(EnDirections), coordinates[2]);

            return true;
        }

        public bool SetMovements(string movements)
        {
            foreach (var movement in movements.Select(x=>x.ToString().ToUpper()))
            {
                switch (movement)
                {
                    case nameof(EnMovements.M):
                        States.Add(new MoveState(this));
                        break;
                    case nameof(EnMovements.R):
                        States.Add(new TurnRightState(this));
                        break;
                    case nameof(EnMovements.L):
                        States.Add(new TurnLeftState(this));
                        break;
                    default:
                        return false;
                }
            }
            return true;
        }

        private void CheckOverflowPosition()
        {
            if(Position.X>Plateau.X || Position.Y > Plateau.Y)
            {
                throw new Exception("Overflow rover position");
            }
        }
    }
}
