using Packt.CloudySkiesAir.Chapter3;
using System.Linq;
public class BoardingProcessor {

  public int CurrentBoardingGroup { get; set; } = 2;
  public BoardingStatus Status { get; set; }
  private int[] _priorityLaneGroups = new[] { 1, 2 };

  public void DisplayBoardingStatus(List<Passenger> passengers, bool? hasBoarded = null) {
    List<Passenger> filteredPassengers = new();
    for (int i = 0; i < passengers.Count; i++) {
      Passenger p = passengers[i];
      if (!hasBoarded.HasValue || p.HasBoarded == hasBoarded) {
        filteredPassengers.Add(p);
      }
    }

    DisplayBoardingHeader();

    foreach (Passenger passenger in filteredPassengers) {
      string statusMessage = passenger.HasBoarded
        ? "Na pokładzie"
        : CanPassengerBoard(passenger);

      Console.WriteLine($"{passenger.FullName,-23} Group {passenger.BoardingGroup}: {statusMessage}");
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

    if (Status != BoardingStatus.PlaneDeparted) {
      if (isMilitary && Status == BoardingStatus.Boarding) {
        return "Przyjąć teraz drogą priorytetową";
      } else if (needsHelp && Status == BoardingStatus.Boarding) {
        return "Przyjąć teraz drogą priorytetową";
      } else if (Status == BoardingStatus.Boarding) {
        if (CurrentBoardingGroup >= group) {
          if (_priorityLaneGroups.Contains(group)) {
            return "Przyjąć teraz drogą priorytetową";
          } else {
            return "Przyjąć teraz";
          }
        } else {
          return "Proszę czekać";
        }
      } else {
        return "Przyjmowanie nierozpoczęte";
      }
    } else {
      return "Samolot odleciał";
    }
  }

}

