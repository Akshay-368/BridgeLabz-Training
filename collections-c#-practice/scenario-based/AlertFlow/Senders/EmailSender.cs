using System;
using AlertFlow.Senders;

using System.Threading.Tasks;

namespace AlertFlow.Senders
{
    public class EmailSender : IAlertSender
    {
        public async Task SendAsync(Alert notification)
        {
            await Task.Delay(1000);
            Console.WriteLine($"Email sent to {notification.Recipient}");
        }
    }
}
