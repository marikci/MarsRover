using MarsRover.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business
{
    public class Plateau : IPlateau
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<IRover> Rovers { get; set; }

        public Plateau()
        {
            Rovers = new List<IRover>();
        }

        public bool SetPositions(string positions)
        {
            if (string.IsNullOrEmpty(positions))
            {
                return false;
            }
            var coordinates = positions.Split(' ');

            if (coordinates.Length != 2)
            {
                return false;
            }

            var isValidXCoordinate = int.TryParse(coordinates[0], out _);
            var isValidYCoordinate = int.TryParse(coordinates[1], out _);

            if (!isValidXCoordinate || !isValidYCoordinate)
            {
                return false;
            }

            this.X = int.Parse(coordinates[0]);
            this.Y = int.Parse(coordinates[0]);

            return true;
        }

        public void RunHandle()
        {
            foreach(var rover in Rovers)
            {
                RunMovements(rover);
            }
        }

        private void RunMovements(IRover rover)
        {
            foreach(var movement in rover.States)
            {
                movement.Handle();
            }
        }
    }
}
