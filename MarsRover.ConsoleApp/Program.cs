using MarsRover.Business;
using MarsRover.Business.Interfaces;
using MarsRover.Business.States;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceProvider serviceProvider = new ServiceCollection()
                                          .AddTransient<IPlateau, Plateau>()
                                          .AddTransient<IRover, Rover>()
                                          .AddTransient<IPosition, Position>()
                                          .AddTransient<IState, MoveState>()
                                          .AddTransient<IState, TurnLeftState>()
                                          .AddTransient<IState, TurnRightState>()
                                          .BuildServiceProvider();

            Console.WriteLine("Mars Rover");
            IPlateau plateau = serviceProvider.GetService<IPlateau>();

            var gridSizeNotOK = true;
            while (gridSizeNotOK)
            {
                Console.WriteLine("Please set Plateau size:");
                gridSizeNotOK = !plateau.SetPositions(Console.ReadLine());
            }

            var isAddNewRover = true;
            var roverNotOK = true;
            while (isAddNewRover || roverNotOK)
            {
                Console.WriteLine("Please add Rover:");
                IRover rover = serviceProvider.GetService<IRover>();
                roverNotOK = !rover.SetPositions(Console.ReadLine());

                if (!roverNotOK)
                {
                    Console.WriteLine("Please add Rover Movements:");
                    rover.SetMovements(Console.ReadLine());
                    plateau.Rovers.Add(rover);

                    Console.WriteLine("Add New Rover Y:N?");
                    if (Console.ReadLine().ToUpper() == "N")
                    {
                        isAddNewRover = false;
                    }
                }
               
            }

            plateau.RunHandle();

            foreach(var rover in plateau.Rovers)
            {
                Console.WriteLine($"{plateau.Rovers.IndexOf(rover)+1}.rover x:{rover.Position.X} y:{rover.Position.Y} Direction: {rover.Position.Direction.ToString()}");
            }

            Console.Read();
        }
    }
}
