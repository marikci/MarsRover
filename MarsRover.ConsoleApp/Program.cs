using MarsRover.Business;
using MarsRover.Business.Interfaces;
using MarsRover.Business.States;
using Microsoft.Extensions.DependencyInjection;
using System;

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
                                          .AddTransient<IMovements, Movements>()
                                          .AddTransient<IState, TurnRightState>()
                                          .BuildServiceProvider();

            Console.WriteLine("Mars Rover");
            IPlateau plateau = serviceProvider.GetService<IPlateau>();

            var gridSizeNotOk = true;
            while (gridSizeNotOk)
            {
                Console.WriteLine("Please set Plateau size:");
                gridSizeNotOk = !plateau.SetSize(Console.ReadLine());
            }

            var isAddNewRover = true;
            var roverNotOk = true;
            while (isAddNewRover || roverNotOk)
            {
                Console.WriteLine("Please add Rover:");
                IRover rover = serviceProvider.GetService<IRover>();
                roverNotOk = !rover.SetPositions(Console.ReadLine());

                if (!roverNotOk)
                {
                    Console.WriteLine("Please add Rover Movements:");
                    rover.SetMovements(Console.ReadLine());
                    rover.Plateau = plateau;
                    plateau.Rovers.Add(rover);

                    Console.WriteLine("Add New Rover Y:N?");
                    if (Console.ReadLine()?.ToUpper() == "N")
                    {
                        isAddNewRover = false;
                    }
                }

            }

            plateau.RunHandle();

            foreach (var rover in plateau.Rovers)
            {
                Console.WriteLine($"{plateau.Rovers.IndexOf(rover) + 1}.rover x:{rover.Position.X} y:{rover.Position.Y} Direction: {rover.Position.Direction.ToString()}");
            }

            Console.Read();
        }


    }
}
