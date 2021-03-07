using AutoFixture.Xunit2;
using Xunit;

namespace XUnitDemo.Test
{
    public class CalculatorShould
    {
        [Fact]
        public void AddTwoPositiveNumbers()
        {
            var sut = new Calculator();

            sut.Add(1);
            sut.Add(2);

            Assert.Equal(3, sut.Value);
        }


        [Fact]
        public void AddZeroAndPositiveNumber()
        {
            var sut = new Calculator();

            sut.Add(0);
            sut.Add(2);

            Assert.Equal(2, sut.Value);
        }


        [Fact]
        public void AddNegativeAndPositiveNumber()
        {
            var sut = new Calculator();

            sut.Add(-5);
            sut.Add(1);

            Assert.Equal(-4, sut.Value);
        }

        [Theory]
        [InlineData(1, 2)] // AddTwoPositiveNumbers
        [InlineData(0, 2)] // AddZeroAndPositiveNumber
        [InlineData(-5, 1)] // AddNegativeAndPositiveNumber
        public void Add(int a, int b)
        {

            var cal = new Calculator();

            cal.Add(a);
            cal.Add(b);

            Assert.Equal(a + b, cal.Value);
        }

        // Test Data driven testing with XUnit
        [Theory]
        [InlineAutoData] // AddTwoPositiveNumbers
        [InlineAutoData(0)] // AddZeroAndPositiveNumber
        [InlineAutoData(-5)] // AddNegativeAndPositiveNumber
        public void AddWithAutoFixture(int a, int b, Calculator cal)
        {
            cal.Add(a);
            cal.Add(b);

            Assert.Equal(a + b, cal.Value);
        }
    }

}
