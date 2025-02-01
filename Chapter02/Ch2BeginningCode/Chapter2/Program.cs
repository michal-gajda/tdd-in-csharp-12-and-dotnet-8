namespace Packt.CloudySkiesAir.Chapter2;

internal class Program
{
    private static void Main()
    {
        int numChecked = 2;
        int numCarryOn = 1;
        int numPassengers = 2;

        BaggageCalculator baggageCalculator = new();
        DateTime travelTime = DateTime.Now;
        decimal price = baggageCalculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelTime);

        Console.WriteLine($"{numChecked} rejestrowanych i {numCarryOn} podręcznych toreb dla {numPassengers} pasażerów kosztuje {price:C}");
    }
}