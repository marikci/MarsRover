using MarsRover.Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace MarsRover.Test
{
    public class PlateauTest : IClassFixture<DependencySetupFixture>
    {
        private readonly ServiceProvider _serviceProvider;

        public PlateauTest(DependencySetupFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public void SetPlateauSize_ShouldReturnTrue_IfRightInput()
        {
            //Arrange
            var size = "5 5";
            var plateau = _serviceProvider.GetService<IPlateau>();

            //Act
            var result = plateau.SetSize(size);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void SetPlateauSize_ShouldReturnFalse_IfWrongInput()
        {
            //Arrange
            var size = "5 5 5 we";
            var plateau = _serviceProvider.GetService<IPlateau>();

            //Act
            var result = plateau.SetSize(size);

            // Assert
            Assert.False(result);
        }


        
    }
}
