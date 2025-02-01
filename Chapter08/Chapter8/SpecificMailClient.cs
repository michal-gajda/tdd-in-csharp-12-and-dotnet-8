namespace Packt.CloudySkiesAir.Chapter8; 

public class SpecificMailClient: IEmailClient {
  private readonly string connectionString;

  public SpecificMailClient(string connectionString) {
    this.connectionString = connectionString;
  }

  public void SendMessage(string email, string message) {
    // Udajemy, że wysyłamy prawdziwą wiadomość
    Console.WriteLine($"Wysyłanie wiadomości do {email}: {message}");
  }
}