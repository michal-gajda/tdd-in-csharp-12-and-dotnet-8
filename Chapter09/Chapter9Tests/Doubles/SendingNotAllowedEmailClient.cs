using Packt.CloudySkiesAir.Chapter9.Flight.Scheduling;

namespace Chapter9Tests.Doubles;

public class SendingNotAllowedEmailClient : IEmailClient {
    public bool SendMessage(string email, string message) {
        Assert.Fail("Nie powinieneś wysłać wiadomości");
        return false;
    }
}