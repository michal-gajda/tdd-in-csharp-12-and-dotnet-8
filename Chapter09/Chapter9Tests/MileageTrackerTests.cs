using Packt.CloudySkiesAir.Chapter9;
using Shouldly;

namespace Chapter9Tests; 

public class MileageTrackerTests {
    [Fact]
    public void NewAccountShouldHaveStartingBalance() {
        // Organizacja
        int expectedMiles = 100;

        // Dzia³anie
        MileageTracker tracker = new();

        // Asercja
        tracker.Balance.ShouldBe(expectedMiles);
    }

    [Fact]
    public void AddMileageShouldIncreaseBalance() {
        // Organizacja
        MileageTracker tracker = new();

        // Dzia³anie
        tracker.AddMiles(50);

        // Asercja
        tracker.Balance.ShouldBe(150);
    }

    [Fact]
    public void RemoveMileageShouldDecreaseBalance() {
        // Organizacja
        MileageTracker tracker = new();
        tracker.AddMiles(900);

        // Dzia³anie
        tracker.RedeemMiles(250);

        // Asercja
        tracker.Balance.ShouldBe(750);
    }

    [Fact]
    public void RemoveMileageShouldPreventNegativeBalance() {
        // Organizacja
        MileageTracker tracker = new();
        int startingBalance = tracker.Balance;

        // Dzia³anie
        tracker.RedeemMiles(2500);

        // Asercja
        tracker.Balance.ShouldBe(startingBalance);
    }

    [Theory]
    [InlineData(900, 250, 750)]
    [InlineData(0, 2500, 100)]
    public void RemoveMileageShouldResultInCorrectBalance(int addAmount, int redeemAmount, int expectedBalance) {
        // Organizacja
        MileageTracker tracker = new();
        tracker.AddMiles(addAmount);

        // Dzia³anie
        tracker.RedeemMiles(redeemAmount);

        // Asercja
        tracker.Balance.ShouldBe(expectedBalance);
    }
}