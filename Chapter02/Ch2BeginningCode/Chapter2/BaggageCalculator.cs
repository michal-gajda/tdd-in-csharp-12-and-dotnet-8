namespace Packt.CloudySkiesAir.Chapter2;

public class BaggageCalculator {

  private decimal holidayFeePercent = 0.1M;
  public decimal HolidayFeePercent {
    get { return holidayFeePercent; }
    set { holidayFeePercent = value; }
  }

  public decimal CalculatePrice(int bags, 
    int carryOn, int passengers, DateTime travelTime) {

    decimal total = 0;

    if (carryOn > 0) {
      Console.WriteLine($"Podręczny: {carryOn * 30M}");
      total += carryOn * 30M;
    }

    if (bags > 0) {
      if (bags <= passengers) {
        Console.WriteLine($"Rejestrowany: {bags * 40M}");
        total += bags * 40M;
      } else {
        decimal checkedFee = (passengers * 40M) + 
          ((bags - passengers) * 50M);

        Console.WriteLine($"Rejestrowany: {checkedFee}");
        total += checkedFee;
      }
    }

    if (travelTime.Month >= 11 || travelTime.Month <= 2) {
      Console.WriteLine("Opłata sezonowa: " + 
        (total * HolidayFeePercent));

      total += total * HolidayFeePercent;
    }

    return total;
  }
  private decimal CalculatePriceFlat(int numBags) {
    decimal total = 0;

    return 100M;

    return numBags * 50M;
  }
}
