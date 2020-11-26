using MarsRover.Business.Interfaces;
using System;

namespace MarsRover.ConsoleApp
{
    class RoverApplication
    {
        private readonly IPlateau _plateau;
        private readonly IRover _rover;
        public RoverApplication(IPlateau plateau, IRover rover)
        {
            _plateau = plateau;
            _rover = rover;
        }
        public void Run()
        {
            string title = @"

                  /$$      /$$                                    
                  | $$$    /$$$                                    
                  | $$$$  /$$$$  /$$$$$$   /$$$$$$   /$$$$$$$      
                  | $$ $$/$$ $$ |____  $$ /$$__  $$ /$$_____/      
                  | $$  $$$| $$  /$$$$$$$| $$  \__/|  $$$$$$       
                  | $$\  $ | $$ /$$__  $$| $$       \____  $$      
                  | $$ \/  | $$|  $$$$$$$| $$       /$$$$$$$/      
                  |__/     |__/ \_______/|__/      |_______/       
             /$$$$$$$                                              
            | $$__  $$                                             
            | $$  \ $$  /$$$$$$  /$$    /$$ /$$$$$$   /$$$$$$      
            | $$$$$$$/ /$$__  $$|  $$  /$$//$$__  $$ /$$__  $$     
            | $$__  $$| $$  \ $$ \  $$/$$/| $$$$$$$$| $$  \__/     
            | $$  \ $$| $$  | $$  \  $$$/ | $$_____/| $$           
            | $$  | $$|  $$$$$$/   \  $/  |  $$$$$$$| $$           
            |__/  |__/ \______/     \_/    \_______/|__/           
                                                             
             ";
            Console.WriteLine(title);

            var gridSizeNotOk = true;
            while (gridSizeNotOk)
            {
                Console.WriteLine("Please set Plateau size:");
                gridSizeNotOk = !_plateau.SetSize(Console.ReadLine());
            }

            var isAddNewRover = true;
            var roverNotOk = true;
            while (isAddNewRover || roverNotOk)
            {
                Console.WriteLine("Please add Rover:");
                roverNotOk = !_rover.SetPositions(Console.ReadLine());

                if (!roverNotOk)
                {
                    var isMovementsNotOK = true;
                    while (isMovementsNotOK)
                    {
                        Console.WriteLine("Please add Rover Movements:");

                        isMovementsNotOK = !_rover.SetMovements(Console.ReadLine());
                        if (!isMovementsNotOK)
                        {
                            _rover.Plateau = _plateau;
                            _plateau.Rovers.Add(_rover);
                        }
                    }


                    Console.WriteLine("Add New Rover Y:N?");
                    if (Console.ReadLine()?.ToUpper() == "N")
                    {
                        isAddNewRover = false;
                    }
                }

            }

            _plateau.RunHandle();

            foreach (var rover in _plateau.Rovers)
            {
                Console.WriteLine($"{rover.Position.X} {rover.Position.Y} {rover.Position.Direction.ToString()}");
            }

            Console.Read();
        }
    }
}
