using Packt.CloudySkiesAir.Chapter8;

public class CargoFlightInfoViolatesLSP : FlightInfo {

  public decimal TonsOfCargo { get; set; }

  public override int RewardMiles => 
    throw new NotSupportedException("Loty towarowe nie dają kilometrów promocyjnych");
}
