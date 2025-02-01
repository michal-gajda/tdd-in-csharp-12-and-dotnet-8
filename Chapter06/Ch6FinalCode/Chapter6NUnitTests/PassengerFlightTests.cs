using Packt.CloudySkiesAir.Chapter6.Flight.Scheduling.Flights;

namespace Chapter6NUnitTests; 

public class PassengerFlightTests {
    [SetUp]
    public void Setup() {
    }

    [Test]
    [TestCase(6)]
    public void AddingAPassengerShouldResultInPassengers(int passengers) {
        // Organizacja
        PassengerFlightInfo flight = new();

        // Dzia³anie
        flight.Load(passengers);

        // Asercja
        int actual = flight.Passengers;
        Assert.AreEqual(passengers, actual);
        Assert.That(actual, Is.EqualTo(passengers));
    }
}