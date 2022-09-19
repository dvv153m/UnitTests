namespace Equation.Tests
{
    public class TestSquareEquation
    {
        /// <summary>
        /// Проверяется, что для уравнения x^2+1 = 0 корней нет
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        [Theory]
        [InlineData(1, 0, 1)]
        public void Solve_DiscremenantNegative_NoRoot(double a, double b, double c)//
        {
            //Arrange            
            int expected = 0;
            SquareEquation _sut = new SquareEquation();

            //Act
            int actual = _sut.Solve(a, b, c).Length;

            //Assert
            Assert.True(expected == actual);
        }

        /// <summary>
        /// Проверяется, что для уравнения x^2-1 = 0 есть два корня кратности 1 (x1=1, x2=-1)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        [Theory]
        [InlineData(1, 0, -1)]
        public void Solve_DiscremenantMoreZero_TwoRoot(double a, double b, double c)
        {
            //Arrange            
            var expected = new double[] { 1, -1 };
            SquareEquation _sut = new SquareEquation();

            //Act
            double[] actual = _sut.Solve(a, b, c);

            //Assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Проверяется, что для уравнения x^2+2x+1 = 0 = 0 есть один корень кратности 2 (x1= x2 = -1)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        [Theory]
        [InlineData(1, 2, 1)]
        [InlineData(0.99999999999999999, 2, 1)]
        public void Solve_DiscremenantZero_SameTwoRoot(double a, double b, double c)
        {
            //Arrange            
            var expected = new double[] { -1, -1 };
            SquareEquation _sut = new SquareEquation();

            //Act
            double[] actual = _sut.Solve(a, b, c);

            //Assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Проверяется, что коэффициент a не может быть равен 0
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        [Theory]
        [InlineData(0, 3, 4)]
        public void Solve_CoefficientAIsZero_ShouldThrowArgumentException(double a, double b, double c)
        {
            //Arrange
            SquareEquation _sut = new SquareEquation();

            //Act            
            var exception = Assert.Throws<ArgumentException>(
                () =>
                {
                    _sut.Solve(a, b, c);
                });

            //Assert
            Assert.NotNull(exception);
            Assert.Equal("Coefficient a must not be equal zero", exception.Message);
        }

        [Theory]
        [InlineData(double.NaN, 3, 4)]
        [InlineData(1, double.NegativeInfinity, 4)]
        [InlineData(1, 2, double.PositiveInfinity)]
        public void Solve_CoefficientsIsNanOrInfiniti_ShouldThrowArgumentException(double a, double b, double c)
        {
            //Arrange
            SquareEquation _sut = new SquareEquation();

            //Act            
            var exception = Assert.Throws<ArgumentException>(
                () =>
                {
                    _sut.Solve(a, b, c);
                });

            //Assert
            Assert.NotNull(exception);
            Assert.Equal("Do not work with NaN and Infinity coefficients", exception.Message);
        }
    }
}