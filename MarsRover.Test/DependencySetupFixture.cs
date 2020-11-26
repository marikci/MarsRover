using Microsoft.Extensions.DependencyInjection;
using MarsRover.Business;
using MarsRover.Business.Interfaces;
using MarsRover.Business.States;

namespace MarsRover.Test
{
    public class DependencySetupFixture
    {
        public DependencySetupFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IPlateau, Plateau>();
            serviceCollection.AddTransient<IRover, Rover>();
            serviceCollection.AddTransient<IPosition, Position>();
            serviceCollection.AddTransient<IState, MoveState>();
            serviceCollection.AddTransient<IState, TurnLeftState>();
            serviceCollection.AddTransient<IState, TurnRightState>();
            serviceCollection.AddTransient<IRover, Rover>();
            serviceCollection.AddTransient<IMovements, Movements>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }

}
