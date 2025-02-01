using Packt.CloudySkiesAir.Chapter7;

namespace Chapter7Tests; 

public class MileageTrackerTests {
    [Fact]
    public void NewAccountShouldHaveStartingBalance() {
        // Organizacja
        int expectedMiles = 100;

        // Dzia³anie
        MileageTracker tracker = new();

        // Asercja
        Assert.Equal(expectedMiles, tracker.Balance);
    }

    [Fact]
    public void AddMileageShouldIncreaseBalance() {
        // Organizacja
        MileageTracker tracker = new();

        // Dzia³anie
        tracker.AddMiles(50);

        // Asercja
        Assert.Equal(150, tracker.Balance);
    }

    [Fact]
    public void RedeemMileageShouldDecreaseBalance() {
        // Organizacja
        MileageTracker tracker = new();
        tracker.AddMiles(900);

        // Dzia³anie
        tracker.RedeemMiles(250);

        // Asercja
        Assert.Equal(750, tracker.Balance);
    }

    [Fact]
    public void RedeemMileageShouldPreventNegativeBalance() {
        // Organizacja
        MileageTracker tracker = new();
        int startingBalance = tracker.Balance;

        // Dzia³anie
        tracker.RedeemMiles(2500);

        // Asercja
        Assert.Equal(startingBalance, tracker.Balance);
    }

    [Theory]
    [InlineData(900, 250, 750)]
    [InlineData(0, 2500, 100)]
    public void RedeemMileageShouldResultInCorrectBalance(int addAmount, int redeemAmount, int expectedBalance) {
        // Organizacja
        MileageTracker tracker = new();
        tracker.AddMiles(addAmount);

        // Dzia³anie
        tracker.RedeemMiles(redeemAmount);

        // Asercja
        Assert.Equal(expectedBalance, tracker.Balance);
    }
}