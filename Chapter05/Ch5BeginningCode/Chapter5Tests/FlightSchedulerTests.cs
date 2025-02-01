using System;
using System.Collections.Generic;
using Packt.CloudySkiesAir.Chapter5.AirTravel;
using Xunit;

namespace Packt.CloudySkiesAir.Chapter5.Tests
{
    public class FlightSchedulerTests
    {
        private readonly FlightScheduler _flightScheduler;

        private readonly Airport _airport1;
        private readonly Airport _airport2;

        public FlightSchedulerTests()
        {
            _flightScheduler = new FlightScheduler();

            _airport1 = new Airport() {
                Code = "DNA",
                Country = "Stany Zjednoczone",
                Name = "Dotnet Airport"
            };
            _airport2 = new Airport() {
                Code = "CSI",
                Country = "Zjednoczone Królestwo",
                Name = "C# International Airport"
            };

        }

        [Fact]
        public void ScheduleFlight_Should_Add_Flight_To_FlightList()
        {
            // Organizacja
            Airport departure = _airport1;
            Airport arrival = _airport2;

            // Dzia³anie
            _flightScheduler.ScheduleFlight("CS2001", departure, arrival, DateTime.Now, DateTime.Now.AddHours(7), 100);

            // Asercja
            IEnumerable<IFlightInfo> result = _flightScheduler.GetAllFlights();
            Assert.Contains(result, f => f.Id == "CS2001");
        }

        [Fact]
        public void SearchShouldReturnMatchingFlights()
        {
            // Organizacja
            DateTime departTime = DateTime.Today.AddHours(6.5);
            _flightScheduler.ScheduleFlight("CS2005", _airport2, _airport1, departTime, departTime.AddHours(14.5), 100);

            // Dzia³anie
            IEnumerable<IFlightInfo> result = _flightScheduler.Search(null, null, DateTime.Today, null, null, null, null, null);

            // Asercja
            Assert.NotEmpty(result);
            Assert.Single(result);
            Assert.Equal("CS2005", result.First().Id);
        }


        [Fact]
        public void SearchShouldNotReturnHiddenFlights() {
            // Organizacja
            DateTime departTime = DateTime.Today.AddHours(6.5);
            _flightScheduler.ScheduleFlight("CS2005", _airport2, _airport1, departTime, departTime.AddHours(14.5), 100);

            // Dzia³anie
            IEnumerable<IFlightInfo> result = _flightScheduler.Search(_airport1, null, null, null, null, null, null, null);

            // Asercja
            Assert.Empty(result);
        }

    }
}
