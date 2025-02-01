namespace Packt.CloudySkiesAir.Chapter8;

// Uwaga: w prawdziwej aplikacji FlightRepository zapewne rozszerzono by o obsługę tych metod.
// Aby jednak zachować czytelność kodu, FlightRepository nie implementuje wszystkich tych składników.

public interface IFlightProvider {
  FlightInfo? FindFlight(string id);
  IEnumerable<FlightInfo> GetActiveFlights();
  IEnumerable<FlightInfo> GetPendingFlights();
  IEnumerable<FlightInfo> GetCompletedFlights();
}
