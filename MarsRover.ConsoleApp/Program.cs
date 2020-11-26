using MarsRover.Business;
using MarsRover.Business.Interfaces;
using MarsRover.Business.States;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRover.ConsoleApp
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<RoverApplication>().Run();
            DisposeServices();

        }
        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<IPlateau, Plateau>();
            services.AddTransient<IRover, Rover>();
            services.AddTransient<IPosition, Position>();
            services.AddTransient<IState, MoveState>();
            services.AddTransient<IState, TurnLeftState>();
            services.AddTransient<IState, TurnRightState>();
            services.AddTransient<IMovements, Movements>();
            services.AddSingleton<RoverApplication>();
            _serviceProvider = services.BuildServiceProvider(true);
        }
         
        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }

    }
}
