using System.Data;
using System.Data.SqlClient;

namespace Packt.CloudySkiesAir.Chapter8;

public class FlightRepository : IDisposable {
  // Zazwyczaj nie będziesz wpisywać łańcucha połączenia do kodu, tylko będziesz wczytywać go z pliku konfiguracyjnego
  private string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CloudySkies;Integrated Security=True;";

  private SqlConnection? _conn;

  public FlightInfo GetFlight(string id) {
    // Tworzy i otwiera połączenie, jeśli obecnie nie jest otwarte
    OpenConnectionIfNeeded();

    // Zapytanie do bazy danych
    const string sql = "SELECT f.Id, f.Departure, f.Arrival, f.Miles FROM Flights f WHERE f.Id = @id";
    using SqlCommand command = new(sql, _conn);
    command.Parameters.AddWithValue("@id", id);

    using SqlDataReader reader = command.ExecuteReader();

    // return Flight
    if (reader.Read()) {
      return GetFlightFromDataReader(reader);
    }

    throw new FlightNotFoundException(id);
  }

  public List<FlightInfo> GetAllFlights() {
    // Tworzy i otwiera połączenie, jeśli obecnie nie jest otwarte
    OpenConnectionIfNeeded();

    // Zapytanie do bazy danych
    const string sql = "SELECT f.Id, f.Departure, f.Arrival, f.Miles FROM Flights f";
    using SqlCommand command = new(sql, _conn);
    using SqlDataReader reader = command.ExecuteReader();

    // Zwrot listy
    List<FlightInfo> flights = new();
    while (reader.Read()) {
      flights.Add(GetFlightFromDataReader(reader));
    }

    return flights;
  }

  public void Dispose() => _conn?.Dispose();

  private static FlightInfo GetFlightFromDataReader(SqlDataReader reader) {
    FlightInfo info = new();
    info.Id = reader.GetString("Id");
    info.DepartureAirport = reader.GetString("Departure");
    info.ArrivalAirport = reader.GetString("Arrival");
    info.Miles = reader.GetInt32("Miles");

    return info;
  }

  private void OpenConnectionIfNeeded() {
    _conn ??= new SqlConnection(connectionString);

    if (_conn.State == ConnectionState.Closed) {
      _conn.Open();
    }
  }
}