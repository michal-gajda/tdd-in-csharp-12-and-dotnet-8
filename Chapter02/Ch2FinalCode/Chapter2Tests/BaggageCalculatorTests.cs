namespace Packt.CloudySkiesAir.Chapter2.Tests;

public class BaggageCalculatorTests
{
    [Fact]
    public void PriceWithNoBagsIsCorrect()
    {
        // Organizacja
        BaggageCalculator calculator = new();
        int numChecked = 0;
        int numCarryOn = 0;
        int numPassengers = 1;
        DateTime travelDate = new(2023, 3, 1);

        // Dzia³anie
        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelDate.Month >= 11 || travelDate.Month <= 2);

        // Asercja
        Assert.Equal(0, actualPrice);
    }

    [Fact]
    public void PriceWithTwoPassengersAndThreeCheckedIsCorrect()
    {
        // Organizacja
        BaggageCalculator calculator = new();
        int numChecked = 3;
        int numCarryOn = 2;
        int numPassengers = 2;
        DateTime travelDate = new(2023, 3, 1);

        // Dzia³anie
        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelDate.Month >= 11 || travelDate.Month <= 2);

        // Asercja
        Assert.Equal(190M, actualPrice);
    }

    [Fact]
    public void PriceWithCarryOnBagIsCorrect()
    {
        // Organizacja
        BaggageCalculator calculator = new();
        int numChecked = 0;
        int numCarryOn = 1;
        int numPassengers = 1;
        DateTime travelDate = new(2023, 3, 1);

        // Dzia³anie
        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelDate.Month >= 11 || travelDate.Month <= 2);

        // Asercja
        Assert.Equal(30M, actualPrice);
    }

    [Fact]
    public void PriceWithTwoCheckedIsCorrect()
    {
        // Organizacja
        BaggageCalculator calculator = new();
        int numChecked = 2;
        int numCarryOn = 1;
        int numPassengers = 1;
        DateTime travelDate = new(2023, 3, 1);

        // Dzia³anie
        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelDate.Month >= 11 || travelDate.Month <= 2);

        // Asercja
        Assert.Equal(120M, actualPrice);
    }

    [Fact]
    public void HolidayPriceIsCorrect()
    {
        // Organizacja
        BaggageCalculator calculator = new();
        int numChecked = 3;
        int numCarryOn = 2;
        int numPassengers = 2;
        DateTime travelDate = new(2023, 12, 19);

        // Dzia³anie
        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelDate.Month >= 11 || travelDate.Month <= 2);

        // Asercja
        Assert.Equal(209M, actualPrice);
    }
}