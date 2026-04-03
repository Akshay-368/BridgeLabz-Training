using System;

namespace AlertFlow
{
    public class AlertMenu
    {
        private readonly IAlertService _service;

        public AlertMenu(IAlertService service)
        {
            _service = service;
        }

        public void Show()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- AlertFlow Menu ---");
                Console.WriteLine("1. Add Alert");
                Console.WriteLine("2. View All Alerts");
                Console.WriteLine("3. Exit");
                Console.Write("Select option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddAlert();
                        break;
                    case "2":
                        _service.DisplayAll();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        private void AddAlert()
        {
            Console.Write("Recipient: ");
            string recipient = Console.ReadLine();

            Console.Write("Message: ");
            string message = Console.ReadLine();

            Console.WriteLine("Priority: 1-High, 2-Medium, 3-Low");
            int priority = int.Parse(Console.ReadLine());

            Console.WriteLine("Type: 1-Email, 2-SMS, 3-AppAlert");
            int type = int.Parse(Console.ReadLine());

            Alert notification = new Alert
            {
                Id = Guid.NewGuid(),
                Recipient = recipient,
                Message = message,
                Priority = (AlertPriority)priority,
                Type = (AlertType)type,
                CreatedTime = DateTime.Now,
                Status = AlertStatus.Pending
            };

            _service.AddAlert(notification);
        }
    }
}
