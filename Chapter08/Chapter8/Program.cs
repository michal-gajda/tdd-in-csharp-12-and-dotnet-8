using Packt.CloudySkiesAir.Chapter8;
using System.Data.SqlClient;

namespace Packt.CloudySkiesAir.Chapter6;

public class Program {
  public static void Main() {
    Console.WriteLine("Witaj w systemie listy lotów Cloudy Skies");
    Console.WriteLine();

    try {
      using FlightRepository repo = new();

      Console.WriteLine("Szukanie lotu CSA1003");
      FlightInfo myFlight = repo.GetFlight("CSA1003");
      Console.WriteLine(myFlight);

      Console.WriteLine();
      Console.WriteLine("Wyszukiwanie wszystkich lotów");
      foreach (FlightInfo aFlight in repo.GetAllFlights()) {
        Console.WriteLine(aFlight);
      }
    }
    catch (SqlException ex) {
      Console.WriteLine($"Problem z połączeniem z bazą danych Cloudy Skies. Być może nie jest przechowywana lokalnie: {ex.Message}");
    }
    catch (FlightNotFoundException ex) {
      Console.WriteLine($"Nie znaleziono lotu {ex.FlightId}");
    }

    Console.WriteLine();
    Console.WriteLine("Zamykanie programu");
  }
}
