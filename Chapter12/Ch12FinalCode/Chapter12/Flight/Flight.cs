using System.Diagnostics.CodeAnalysis;

namespace Packt.CloudySkiesAir.Chapter12.Flight;

public class Flight {
  [SuppressMessage("Wydajność", "CA1822:Oznacz składowe jako statyczne", 
    Justification = "Planowana praca z danymi egzemplarza w przyszłości")]
  public string BuildMessage(string id, string status) {
    return $"Lot {id} jest {status}";
  }
}

