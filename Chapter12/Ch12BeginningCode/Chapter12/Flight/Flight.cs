namespace Packt.CloudySkiesAir.Chapter12.Flight;

public class Flight {
  public string BuildMessage(string id, string status) {
    return $"Lot {id} jest {status}";
  }
}

