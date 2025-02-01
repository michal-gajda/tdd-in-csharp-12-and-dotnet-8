namespace Packt.CloudySkiesAir.Chapter2; 

public class Fee {
  public decimal Total { get; set; }

  public void ChargeCarryOnBaggageFee(decimal fee) {
    Console.WriteLine($"Podręczny: {fee}");
    Total += fee;
  }
  public void ChargeCheckedBaggageFee(decimal fee) {
    Console.WriteLine($"Rejestrowany: {fee}");
    Total += fee;
  }
}
