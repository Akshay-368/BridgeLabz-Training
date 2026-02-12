using System;
using System.ComponentModel.DataAnnotations;

namespace AlertFlow
{
    public class Alert
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [AlertRecipient]
        public string Recipient { get; set; }


        [Required]
        public string Message { get; set; }

        public AlertPriority Priority { get; set; }
        public AlertType Type { get; set; }

        public DateTime CreatedTime { get; set; }

        public AlertStatus Status { get; set; }
    }

    public enum AlertPriority
    {
        High = 1,
        Medium = 2,
        Low = 3
    }

    public enum AlertType
    {
        Email = 1,
        Sms = 2,
        AppAlert = 3
    }

    public enum AlertStatus
    {
        Pending,
        Processing,
        Sent,
        Failed
    }
}
