using Packt.CloudySkiesAir.Chapter3;
using System.Linq;
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
    ? "Na pokładzie"
    : CanPassengerBoard(passenger);

  Console.WriteLine($"{passenger.FullName,-23} Grupa {passenger.BoardingGroup}: {statusMessage}");
}
}

  private void DisplayBoardingHeader() {
    switch (Status) {
      case BoardingStatus.NotStarted:
        Console.WriteLine("Przyjmowanie na pokład zakończone i samolot odleciał.");
        break;

      case BoardingStatus.Boarding:
        if (_priorityLaneGroups.Contains(CurrentBoardingGroup)) {
          Console.WriteLine($"Priorytetowa grupa {CurrentBoardingGroup}");
        } else {
          Console.WriteLine($"Grupa {CurrentBoardingGroup}");
        }
        break;

      case BoardingStatus.PlaneDeparted:
        Console.WriteLine("Przyjmowanie na pokład zakończone i samolot odleciał.");
        break;

      default:
        Console.WriteLine($"Nieznany status : {Status}");
        break;
    }

    Console.WriteLine();
  }

  public string CanPassengerBoard(Passenger passenger) {
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

