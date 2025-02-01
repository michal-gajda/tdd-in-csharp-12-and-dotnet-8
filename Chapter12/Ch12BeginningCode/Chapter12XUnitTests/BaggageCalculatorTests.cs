using Packt.CloudySkiesAir.Chapter12.Flight.Baggage;

namespace Chapter12UnitTests {
    public class BaggageCalculatorTests {
        [Fact]
        public void CarryOnBaggageIsPricedCorrectly() {
            // Organizacja
            BaggageCalculator calculator = new();
            int carryOnBags = 2;
            int checkedBags = 0;
            int passengers = 1;
            bool isHoliday = false;

            // Dzia³anie
            decimal result = calculator.CalculatePrice(checkedBags, carryOnBags, passengers, isHoliday);

            // Asercja
            Assert.Equal(60m, result);
        }

        [Fact]
        public void FirstCheckedBagShouldCostExpectedAmount() {
            // Organizacja
            BaggageCalculator calculator = new();
            int carryOnBags = 0;
            int checkedBags = 1;
            int passengers = 1;
            bool isHoliday = false;

            // Dzia³anie
            decimal result = calculator.CalculatePrice(checkedBags, carryOnBags, passengers, isHoliday);

            // Asercja
            Assert.Equal(40m, result);
        }


        [Theory]
        [InlineData(0, 0, 1, false, 0)]
        [InlineData(2, 3, 2, false, 190)]
        [InlineData(2, 1, 1, false, 100)]
        [InlineData(2, 3, 2, true, 209)]
        public void BaggageCalculatorCalculatesCorrectPrice(int carryOnBags, int checkedBags, int passengers, bool isHoliday, decimal expected) {
            // Organizacja
            BaggageCalculator calculator = new();

            // Dzia³anie
            decimal result = calculator.CalculatePrice(checkedBags, carryOnBags, passengers, isHoliday);

            // Asercja
            Assert.Equal(expected, result);
        }

    }
}