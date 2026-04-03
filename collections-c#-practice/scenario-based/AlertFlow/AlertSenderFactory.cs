using AlertFlow.Senders;

namespace AlertFlow
{
    public static class AlertSenderFactory
    {
        public static IAlertSender Create(AlertType type)
        {
            return type switch
            {
                AlertType.Email => new EmailSender(),
                AlertType.Sms => new SmsSender(),
                AlertType.AppAlert => new AppAlertSender(),
                _ => throw new System.ArgumentException("Invalid type")
            };
        }
    }
}
