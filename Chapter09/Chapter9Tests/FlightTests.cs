using Packt.CloudySkiesAir.Chapter9.Flight;
using Shouldly;

namespace Chapter9Tests; 

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
        message.ShouldBe("Lot CSA1234 jest na czas");
    }
}