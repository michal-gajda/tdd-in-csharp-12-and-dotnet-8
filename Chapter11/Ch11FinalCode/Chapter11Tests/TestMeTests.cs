using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Packt.CloudySkiesAir.Chapter11.Tests
{
    public class TestMeTests
    {
        [Fact]
        public void CalculateLargestNumberWithoutASeven_ThrowsException_WhenInputIsNull()
        {
            // Organizacja
            Mock<INumberProvider> mockProvider = new Mock<INumberProvider>();
            mockProvider.Setup(x => x.GenerateNumbers()).Returns((IEnumerable<int>)null);

            // Dzia³anie & Assert            
            Assert.Throws<ArgumentNullException>(() => TestMe.CalculateLargestNumberWithoutASeven(mockProvider.Object));
        }

        [Fact]
        public void CalculateLargestNumberWithoutASeven_ReturnsLargestNumberWithoutSeven_WhenInputIsValid()
        {
            // Organizacja
            Mock<INumberProvider> mockProvider = new Mock<INumberProvider>();
            mockProvider.Setup(x => x.GenerateNumbers()).Returns(new List<int> { 17, 2, 13, 4, 22, 44 });

            // Dzia³anie
            int result = TestMe.CalculateLargestNumberWithoutASeven(mockProvider.Object);

            // Asercja
            Assert.Equal(44, result);
        }
    }
}
