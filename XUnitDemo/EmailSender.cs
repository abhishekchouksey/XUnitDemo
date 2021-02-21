using System.Diagnostics;

namespace XUnitDemo
{
    public class EmailSender : IEmailSender
    {
        public void Send(EmailMessage message)
        {
            Debug.WriteLine($"Sending email to : {message.To}");
            Debug.WriteLine($"Sending email to : {message.Body}");
        }
    }
}
