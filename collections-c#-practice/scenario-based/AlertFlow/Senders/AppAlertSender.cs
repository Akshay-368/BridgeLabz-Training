using System;
using AlertFlow.Senders;

using System.Threading.Tasks;

namespace AlertFlow.Senders
{
    public class AppAlertSender : IAlertSender
    {
        public async Task SendAsync(Alert notification)
        {
            await Task.Delay(500);
            Console.WriteLine($"App alert sent to {notification.Recipient}");
        }
    }
}
