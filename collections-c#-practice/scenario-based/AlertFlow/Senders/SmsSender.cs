using System;
using AlertFlow.Senders;

using System.Threading.Tasks;

namespace AlertFlow.Senders
{
    public class SmsSender : IAlertSender
    {
        public async Task SendAsync(Alert notification)
        {
            await Task.Delay(800);
            Console.WriteLine($"SMS sent to {notification.Recipient}");
        }
    }
}
