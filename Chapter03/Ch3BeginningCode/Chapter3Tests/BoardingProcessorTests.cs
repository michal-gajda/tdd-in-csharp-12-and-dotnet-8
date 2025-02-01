using Packt.CloudySkiesAir.Chapter3;

namespace Packt.CloudySkiesAir.Chapter3.Tests;

public class BoardingProcessorTests {

    [Theory]
    [InlineData(false, 4, false, 4, "Przyj¹æ teraz")]
    [InlineData(false, 3, false, 2, "Proszê czekaæ")]
    [InlineData(false, 2, true, 2, "Przyj¹æ teraz drog¹ priorytetow¹")]
    [InlineData(false, 3, true, 2, "Przyj¹æ teraz drog¹ priorytetow¹")]
    [InlineData(false, 1, false, 2, "Przyj¹æ teraz drog¹ priorytetow¹")]
    [InlineData(true, 7, false, 1, "Przyj¹æ teraz drog¹ priorytetow¹")]
    [InlineData(true, 1, true, 2, "Przyj¹æ teraz drog¹ priorytetow¹")]
    [InlineData(true, 3, false, 2, "Przyj¹æ teraz drog¹ priorytetow¹")]
    [InlineData(true, 3, true, 2, "Przyj¹æ teraz drog¹ priorytetow¹")]
    public void CanPassengerBoard_ShouldReturnExpectedResult(
        bool isMilitary,
        int passengerGroup,
        bool needsHelp,
        int currentGroup,
        string expectedResult) {

        // Organizacja
        BoardingProcessor bp = new() {
            Status = BoardingStatus.Boarding,
            CurrentBoardingGroup = currentGroup,
        };

        Passenger passenger = new() {
            FirstName = "Test",
            LastName = "Passenger",
            IsMilitary = isMilitary,
            BoardingGroup = passengerGroup,
            NeedsHelp = needsHelp,
        };

        // Dzia³anie
        string result = bp.CanPassengerBoard(passenger);

        // Asercja
        Assert.Equal(expectedResult, result);
    }
}
