namespace Packt.CloudySkiesAir.Chapter12.Flight.Boarding;

public class BoardingProcessor {

  public int CurrentBoardingGroup { get; set; } = 2;
  public BoardingStatus Status { get; set; }
  private int[] _priorityLaneGroups = new[] { 1, 2 };

  public void DisplayBoardingStatus(List<Passenger> passengers, bool? hasBoarded = null) {
    passengers = passengers.Where(p => !hasBoarded.HasValue ||
                                       p.HasBoarded == hasBoarded)
                           .ToList();

    DisplayBoardingHeader();

    foreach (Passenger passenger in passengers) {
      string statusMessage = passenger.HasBoarded
        ? "Onboard"
        : BuildMessage(passenger);

      Console.WriteLine($"{passenger.FullName,-23} Group {passenger.BoardingGroup}: {statusMessage}");
    }
  }

  private void DisplayBoardingHeader() {
    switch (Status) {
      case BoardingStatus.NotStarted:
        Console.WriteLine("Przyjmowanie zakończone i samolot odleciał.");
        break;

      case BoardingStatus.Boarding:
        if (_priorityLaneGroups.Contains(CurrentBoardingGroup)) {
          Console.WriteLine($"Priorytetowa grupa przyjmowania {CurrentBoardingGroup}");
        } else {
          Console.WriteLine($"Grupa przyjmowania {CurrentBoardingGroup}");
        }
        break;

      case BoardingStatus.PlaneDeparted:
        Console.WriteLine("Przyjmowanie zakończone i samolot odleciał.");
        break;

      default:
        Console.WriteLine($"Nieznany status przyjmowania: {Status}");
        break;
    }

    Console.WriteLine();
  }

  public string BuildMessage(Passenger passenger) {
    bool isMilitary = passenger.IsMilitary;
    bool needsHelp = passenger.NeedsHelp;
    int group = passenger.BoardingGroup;

    return Status switch {
      BoardingStatus.PlaneDeparted => "Samolot odleciał",
      BoardingStatus.NotStarted => "Przyjmowanie nierozpoczęte",
      BoardingStatus.Boarding when isMilitary || needsHelp => "Przyjąć teraz drogą priorytetową",
      BoardingStatus.Boarding when CurrentBoardingGroup < group => "Proszę czekać",
      BoardingStatus.Boarding when _priorityLaneGroups.Contains(group) => "Przyjąć teraz drogą priorytetową",
      BoardingStatus.Boarding => "Przyjąć teraz",
      _ => throw new NotSupportedException($"Nieobsługiwany status {Status}"),
    };
  }
}
