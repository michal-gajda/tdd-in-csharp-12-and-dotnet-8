using Packt.CloudySkiesAir.Chapter12.Flight.Scheduling;
using Packt.CloudySkiesAir.Chapter12.Flight.Scheduling.Flights;

namespace Chapter12UnitTests;

public class FlightSchedulerTests {

    private readonly Airport _airport1;
    private readonly Airport _airport2;

    public FlightSchedulerTests() {
        _airport1 = new() {
            Code = "DNA",
            Country = "Stany Zjednoczone",
            Name = "Dotnet Airport"
        };
        _airport2 = new() {
            Code = "CSI",
            Country = "Zjednoczone Królestwo",
            Name = "C# International Airport"
        };
    }

    [Fact]
    public void ScheduleFlightShouldAddFlight() {
        // Organizacja
        FlightScheduler scheduler = new();
        PassengerFlightInfo flight = CreateFlight("CS2024");

        // Działanie
        scheduler.ScheduleFlight(flight);

        // Asercja
        IEnumerable<IFlightInfo> result = scheduler.GetAllFlights();
        Assert.NotNull(result);
        Assert.Contains(flight, result);
    }

    private PassengerFlightInfo CreateFlight(string id)
      => new() {
          Id = id,
          Status = FlightStatus.OnTime,
          Departure = new AirportEvent(_airport1) {
              Time = DateTime.Now
          },
          Arrival = new AirportEvent(_airport2) {
              Time = DateTime.Now.AddHours(2)
          }
      };

    [Fact]
    public void RemoveShouldRemoveFlight() {
        // Organizacja
        FlightScheduler scheduler = new();
        PassengerFlightInfo flight = CreateFlight("CS2024");
        scheduler.ScheduleFlight(flight);

        // Działanie
        scheduler.RemoveFlight(flight);

        // Asercja
        IEnumerable<IFlightInfo> result = scheduler.GetAllFlights();
        Assert.NotNull(result);
        Assert.DoesNotContain(flight, result);
    }
}
