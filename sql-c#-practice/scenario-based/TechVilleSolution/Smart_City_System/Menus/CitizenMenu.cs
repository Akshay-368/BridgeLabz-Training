// File: Menus/CitizenMenu.cs

using System;
using SmartCitySmartCity.Services;
using SmartCitySmartCity.Utilities;
using SmartCitySmartCity.Exceptions;

namespace SmartCitySmartCity.Menus
{
    public class CitizenMenu
    {
        private readonly CitizenService _service;

        public CitizenMenu(CitizenService service)
        {
            _service = service;
        }

        public void Show()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- Citizen Menu ---");
                Console.WriteLine("1. Register Citizen");
                Console.WriteLine("2. View All Citizens");
                Console.WriteLine("3. Search Citizen");
                Console.WriteLine("4. Update Citizen Income");
                Console.WriteLine("5. Back");
                Console.Write("Select Option: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            RegisterCitizen();
                            break;

                        case "2":
                            _service.DisplayAllCitizens();
                            break;

                        case "3":
                            SearchCitizen();
                            break;

                        case "4":
                            UpdateIncome();
                            break;

                        case "5":
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionLogger.Log(ex);
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }
            }
        }

        private void RegisterCitizen()
        {
            try
            {
                Console.Write("\nName: ");
                string name = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();

                int age = ValidationHelper.ReadInt("Age: ");
                double income = ValidationHelper.ReadDouble("Income: ");
                int residency = ValidationHelper.ReadInt("Residency Years: ");
                int zone = ValidationHelper.ReadInt("Zone (0-4): ");
                int sector = ValidationHelper.ReadInt("Sector (0-4): ");

                _service.RegisterCitizen(
                    name,
                    email,
                    age,
                    income,
                    residency,
                    zone,
                    sector);

                Console.WriteLine("Citizen registered successfully!");
            }
            catch (UnderageException ex)
            {
                ExceptionLogger.Log(ex);
                Console.WriteLine($"Age Error: {ex.Message}");
            }
            catch (DuplicateCitizenException ex)
            {
                ExceptionLogger.Log(ex);
                Console.WriteLine($"Duplicate Error: {ex.Message}");
            }
            catch (InvalidIncomeException ex)
            {
                ExceptionLogger.Log(ex);
                Console.WriteLine($"Income Error: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                ExceptionLogger.Log(ex);
                Console.WriteLine($"Validation Error: {ex.Message}");
            }
        }

        private void SearchCitizen()
        {
            try
            {
                Console.Write("Enter name to search: ");
                string name = Console.ReadLine();

                var citizen = _service.SearchByName(name);

                if (citizen == null)
                {
                    Console.WriteLine("Citizen not found.");
                    return;
                }

                Console.WriteLine("\nCitizen Found:");
                Console.WriteLine($"Name: {citizen.Name}");
                Console.WriteLine($"Email: {citizen.Email}");
                Console.WriteLine($"Category: {citizen.EligibilityCategory}");
            }
            catch (Exception ex)
            {
                ExceptionLogger.Log(ex);
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void UpdateIncome()
        {
            try
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine();

                double newIncome = ValidationHelper.ReadDouble("New Income: ");

                _service.UpdateCitizenIncome(name, newIncome);

                Console.WriteLine("Income updated successfully.");
            }
            catch (InvalidIncomeException ex)
            {
                ExceptionLogger.Log(ex);
                Console.WriteLine($"Income Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                ExceptionLogger.Log(ex);
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
