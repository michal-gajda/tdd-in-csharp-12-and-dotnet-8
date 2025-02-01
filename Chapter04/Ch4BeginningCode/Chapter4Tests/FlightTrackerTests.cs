using System;
using Packt.CloudySkiesAir.Chapter4;
using Shouldly;
using Xunit;

namespace PacktCloudySkiesAirTests.Chapter4
{
    public class FlightTrackerTests
    {
        private readonly FlightTracker _target;

        public FlightTrackerTests()
        {
            _target = new FlightTracker();
        }

        [Fact]
        public void ScheduleNewFlight_Should_Add_Flight_To_List()
        {
            // Organizacja
            var flightId = "F01";
            var destination = "New York";
            var departureTime = DateTime.Now;
            var gate = "A02";

            // Dzia³anie
            var flight = _target.ScheduleNewFlight(flightId, destination, departureTime, gate);

            // Asercja
            flight.ShouldNotBeNull();
            flight.Id.ShouldBe(flightId);
            flight.Destination.ShouldBe(destination);
            flight.DepartureTime.ShouldBe(departureTime);
            flight.Status.ShouldBe(FlightStatus.Inbound);
        }

        [Fact]
        public void DelayFlight_Should_Update_Departure_Time_And_Status()
        {
            // Organizacja
            var flightId = "F01";
            var originalDepartureTime = DateTime.Now.AddHours(1);
            var newDepartureTime = DateTime.Now.AddHours(2);
            _target.ScheduleNewFlight(flightId, "New York", originalDepartureTime, "A01");

            // Dzia³anie
            var actual = _target.DelayFlight(flightId, newDepartureTime);

            // Asercja
            Assert.NotNull(actual);
            Assert.Equal(newDepartureTime, actual?.DepartureTime);
            Assert.Equal(FlightStatus.Delayed, actual?.Status);
        }

        [Fact]
        public void MarkFlightsArrived_Should_Update_Arrival_Time_And_Status()
        {
            // Organizacja
            var flightId = "F01";
            var arrivalTime = DateTime.Now.AddMinutes(15);
            _target.ScheduleNewFlight(flightId, "New York", DateTime.Now, "A01");

            // Dzia³anie
            var actual = _target.MarkFlightArrived(arrivalTime, flightId);

            // Asercja
            Assert.NotNull(actual);
            Assert.Equal(arrivalTime, actual?.ArrivalTime);
            Assert.Equal(FlightStatus.OnTime, actual?.Status);
        }

        [Fact]
        public void MarkFlightDeparted_Should_Update_Departure_Time_And_Status()
        {
            // Organizacja
            var flightId = "F01";
            var originalDepartureTime = DateTime.Now;
            var departureTime = DateTime.Now.AddMinutes(15);
            _target.ScheduleNewFlight(flightId, "New York", originalDepartureTime, "A01");

            // Dzia³anie
            var actual = _target.MarkFlightDeparted(flightId, departureTime);

            // Asercja
            Assert.NotNull(actual);
            Assert.Equal(departureTime, actual?.DepartureTime);
            Assert.Equal(FlightStatus.Departed, actual?.Status);
        }
    }
}
