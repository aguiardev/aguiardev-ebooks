namespace Calculator.Tests
{
    public class CalculatorTests
    {
        //[Fact(DisplayName = "Given valid numbers, when sum then should succcess.")]
        [Fact]
        public void GivenValidNumbers_WhenSum_ThenShouldSucccess()
        {
            //arrange
            const int resultExpected = 5;
            const int firstNumber = 3;
            const int secondNumber = 2;

            //act
            var resultActual = Calculator.Sum(firstNumber, secondNumber);

            //assert
            Assert.Equal(resultExpected, resultActual);
        }

        [Fact]
        public void GivenInvalidNumbers_WhenSum_ThenShouldFail()
        {
            //arrange
            const int resultExpected = -1;
            const int firstNumber = -3;
            const int secondNumber = 2;

            //act
            var resultActual = Calculator.Sum(firstNumber, secondNumber);

            //assert
            Assert.Equal(resultExpected, resultActual);
        }
    }
}