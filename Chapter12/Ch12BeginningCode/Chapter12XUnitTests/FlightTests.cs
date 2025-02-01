using Packt.CloudySkiesAir.Chapter12.Flight;

namespace Chapter12UnitTests;

public class FlightTests {
    [Fact]
    public void GeneratedMessageShouldBeCorrect() {
        // Organizacja
        Flight flight = new();
        string id = "CSA1234";
        string status = "Na czas";
        // Działanie
        string message = flight.BuildMessage(id, status);

        // Asercja
        Assert.Equal("Lot CSA1234 jest na czas", message);
    }
}