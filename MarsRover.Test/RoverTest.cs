using MarsRover.Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace MarsRover.Test
{
    public class RoverTest : IClassFixture<DependencySetupFixture>
    {
        private readonly ServiceProvider _serviceProvider;

        public RoverTest(DependencySetupFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public void SetRoverPositions_ShouldReturnTrue_IfRightInput()
        {
            //Arrange
            var positions = "1 2 N";
            var rover = _serviceProvider.GetService<IRover>();

            //Act
            var result = rover.SetPositions(positions);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void SetRoverPositions_ShouldReturnFalse_IfWrongInput()
        {
            //Arrange
            var positions = "1 O NM";
            var rover = _serviceProvider.GetService<IRover>();

            //Act
            var result = rover.SetPositions(positions);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void SetRoverMovements_ShouldReturnTrue_IfRightInput()
        {
            //Arrange
            var positions = "LMLMLMLMM";
            var rover = _serviceProvider.GetService<IRover>();

            //Act
            var result = rover.SetMovements(positions);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void SetRoverMovements_ShouldReturnFalse_IfWrongInput()
        {
            //Arrange
            var positions = "LMLMLMLMMOPR";
            var rover = _serviceProvider.GetService<IRover>();

            //Act
            var result = rover.SetPositions(positions);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void RunRoverMovements_ShouldReturnRightPosition_IfRightInput()
        {
            //Arrange
            var plateauSize = "5 5";
            var roverPosition = "1 2 N";
            var roverMovements = "LMLMLMLMM";
            var rightPosition = "1 3 N";
            var plateau = _serviceProvider.GetService<IPlateau>();
            var rover = _serviceProvider.GetService<IRover>();

            //Act
            plateau.SetSize(plateauSize);
            rover.SetPositions(roverPosition);
            rover.SetMovements(roverMovements);

            rover.Plateau = plateau;
            plateau.Rovers.Add(rover);
            plateau.RunHandle();

            // Assert
            Assert.Equal(rightPosition, $"{rover.Position.X} {rover.Position.Y} {rover.Position.Direction.ToString()}");
        }

        [Fact]
        public void RunRoverMovements_ShouldReturnWrongPosition_IfWrongInput()
        {
            //Arrange
            var plateauSize = "5 5";
            var roverPosition = "1 2 N";
            var roverMovements = "LMLMLMLMMR";
            var rightPosition = "1 3 N";
            var plateau = _serviceProvider.GetService<IPlateau>();
            var rover = _serviceProvider.GetService<IRover>();

            //Act
            plateau.SetSize(plateauSize);
            rover.SetPositions(roverPosition);
            rover.SetMovements(roverMovements);

            rover.Plateau = plateau;
            plateau.Rovers.Add(rover);
            plateau.RunHandle();

            // Assert
            Assert.NotEqual(rightPosition, $"{rover.Position.X} {rover.Position.Y} {rover.Position.Direction.ToString()}");
        }
    }
}
