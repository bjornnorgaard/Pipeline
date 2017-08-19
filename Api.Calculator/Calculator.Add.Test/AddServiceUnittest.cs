using Calculator.Add.Service;
using Xunit;

namespace Calculator.Add.Test
{
    public class AddServiceUnittest
    {
        private readonly AddService _uut;

        public AddServiceUnittest()
        {
            _uut = new AddService();
        }

        [Theory]
        [InlineData(0, -1)]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, -1)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        [InlineData(-1, -1)]
        [InlineData(-1, 0)]
        [InlineData(-1, 1)]
        public void Add_AddingNumbers_ReturnsSum(int a, int b)
        {
            // Arrange
            var expected = a + b;

            // Act
            var result = _uut.Add(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Add_SameNumber_ReturnsDouble()
        {
            // Arrange
            var a = 5;
            var b = 3;
            var expected = a + b;

            // Act
            var result = _uut.Add(a, 4);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
