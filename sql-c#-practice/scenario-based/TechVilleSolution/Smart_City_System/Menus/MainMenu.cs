using System;
using SmartCitySmartCity.Menus;
using Hospital_Management_System;

namespace SmartCitySmartCity.Menus
{
    public class MainMenu
    {
        private readonly CitizenMenu _citizenMenu;
        private readonly ServiceMenu _serviceMenu;
        private readonly DataMenu _dataMenu;
        private readonly SystemMenu _systemMenu;
        private readonly ReportMenu _reportMenu;

        public MainMenu(CitizenMenu citizenMenu, ServiceMenu serviceMenu, DataMenu dataMenu, SystemMenu systemMenu, ReportMenu reportMenu)
        {
            _citizenMenu = citizenMenu;
            _serviceMenu = serviceMenu;
            _dataMenu = dataMenu;
            _systemMenu = systemMenu;
            _reportMenu = reportMenu;

        }

        public void Show()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n SmartCity: Smart City Management System ");
                Console.WriteLine("1. Citizen Management");
                Console.WriteLine("2. Service Management");
                Console.WriteLine("3. Data Management");
                Console.WriteLine("4. Reports & Analytics");
                Console.WriteLine("5. System Tools");
                Console.WriteLine("6. Healthcare Services ");
                Console.WriteLine("0. Exit");
                Console.Write("Select Option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _citizenMenu.Show();
                        break;

                    case "2":
                        _serviceMenu.Show();
                        break;

                    case "3":
                        _dataMenu.DisplayMenu();
                        break;

                    case "4":
                        _reportMenu.Display();
                        break;

                    case "5":
                        _systemMenu.DisplayMenu();
                        break;

                    case"6" :
                        Console.WriteLine ( " Redirection to TechVille Healthcare System ... ");
                        HospitalEntry.StartHospital().Wait();
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
