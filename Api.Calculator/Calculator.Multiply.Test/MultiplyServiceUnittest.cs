using Calculator.Add.Interface;
using Calculator.Multiply.Service;
using NSubstitute;
using Xunit;

namespace Calculator.Multiply.Test
{
    public class MultiplyServiceUnittest
    {
        private readonly MultiplyService _uut;

        public MultiplyServiceUnittest()
        {
            var addService = Substitute.For<IAddService>();

            const int max = 2;
            const int min = -2;
            for (var i = min; i <= max; i++)
            {
                for (var j = min; j <= max; j++)
                {
                    addService.Add(i, j).Returns(i + j);
                }
            }

            _uut = new MultiplyService(addService);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 0)]
        [InlineData(2, 1)]
        [InlineData(2, 2)]
        public void Multiply(int a, int b)
        {
            // Arrange
            var expected = a * b;

            // Act
            var result = _uut.Multiply(a, b);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
