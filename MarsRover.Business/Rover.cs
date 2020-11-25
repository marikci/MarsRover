using MarsRover.Business.Interfaces;
using MarsRover.Business.States;
using MarsRover.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business
{
    public class Rover : IRover
    {
        public IPosition Position { get; set; }
        public IPlateau Plateau { get; set; }
        public List<IState> States { get; set; }

        public Rover(IPosition position, IPlateau plateau)
        {
            Position = position;
            Plateau = plateau;
            States = new List<IState>();
        }

        public Rover()
        {
            States = new List<IState>();
        }
        public void Move()
        {
            Position = Movements.Move(Position);
            CheckOverflowPosition();
        }

        public void TurnLeft()
        {
            Position = Movements.TurnLeft(Position);
        }

        public void TurnRight()
        {
            Position = Movements.TurnRight(Position);
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
            var isDirectionOK = Enum.IsDefined(typeof(EnDirections), coordinates[2]);

            if (!isValidXCoordinate || !isValidYCoordinate || !isDirectionOK)
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
            foreach(var movement in movements)
            {
                switch (char.ToUpper(movement))
                {
                    case 'M':
                        States.Add(new MoveState(this));
                        break;
                    case 'R':
                        States.Add(new TurnRightState(this));
                        break;
                    case 'L':
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
