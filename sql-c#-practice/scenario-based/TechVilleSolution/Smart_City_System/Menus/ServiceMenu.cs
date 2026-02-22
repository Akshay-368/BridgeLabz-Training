// File: Menus/ServiceMenu.cs

using System;
using SmartCitySmartCity.Models;
using SmartCitySmartCity.Services;
using SmartCitySmartCity.Utilities;

namespace SmartCitySmartCity.Menus
{
    public class ServiceMenu
    {
        private readonly ServiceManager _serviceManager;

        public ServiceMenu(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public void Show()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nService Management");
                Console.WriteLine("------------------");
                Console.WriteLine("1. Add Healthcare Service");
                Console.WriteLine("2. Add Education Service");
                Console.WriteLine("3. Add Premium Healthcare Service");
                Console.WriteLine("4. View Services");
                Console.WriteLine("5. Apply for Service");
                Console.WriteLine("6. Process Next Service");
                Console.WriteLine("7. Cancel Last Processed Service");
                Console.WriteLine("8. View Service History");
                Console.WriteLine("9. Queue Status");
                Console.WriteLine("0. Back");

                Console.Write("Select Option: ");
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddHealthcare();
                            break;

                        case "2":
                            AddEducation();
                            break;

                        case "3":
                            AddPremiumHealthcare();
                            break;

                        case "4":
                            _serviceManager.DisplayAllServices();
                            break;

                        case "5":
                            ApplyForService();
                            break;

                        case "6":
                            _serviceManager.ProcessNextRequest();
                            break;

                        case "7":
                            _serviceManager.CancelLastService();
                            break;

                        case "8":
                            _serviceManager.ShowHistory();
                            break;

                        case "9":
                            _serviceManager.ShowQueueStatus();
                            break;

                        case "0":
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private void AddHealthcare()
        {
            double cost = ValidationHelper.ReadDouble("Base Cost: ");
            bool emergency = true;

            var service = new HealthcareService(cost, emergency);
            _serviceManager.AddService(service);

            Console.WriteLine("Healthcare Service Added.");
        }

        private void AddPremiumHealthcare()
        {
            double cost = ValidationHelper.ReadDouble("Base Cost: ");
            double premiumFee = ValidationHelper.ReadDouble("Premium Fee: ");

            bool emergency = true;

            var service = new PremiumHealthcareService(cost, emergency, premiumFee);
            _serviceManager.AddService(service);

            Console.WriteLine("Premium Healthcare Service Added.");
        }

        private void AddEducation()
        {
            double cost = ValidationHelper.ReadDouble("Base Cost: ");

            Console.Write("Course Type: ");
            string type = Console.ReadLine();

            var service = new EducationService(cost, type);
            _serviceManager.AddService(service);

            Console.WriteLine("Education Service Added.");
        }

        private void ApplyForService()
        {
            Console.Write("Enter Citizen Name: ");
            string name = Console.ReadLine();

            _serviceManager.AddServiceRequest(name);
        }
    }
}
