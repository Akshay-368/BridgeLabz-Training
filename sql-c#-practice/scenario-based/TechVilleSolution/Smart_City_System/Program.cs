// File: Program.cs

using System;
using SmartCitySmartCity.Data;
using SmartCitySmartCity.Menus;
using SmartCitySmartCity.Services;
/*
Created using 
first : dotnet new sln -n TechVilleSolution
Then : dotnet sln add SmartCitySystem/SmartCitySystem.csproj
dotnet sln add Hospital_Management_System/Backend/DatabaseConnection.csproj

dir /s Program.cs

dotnet add Smart_City_System reference Hospital_Management_System/Backend/DatabaseConnection.csproj
(so that smart city can access Hospital_Management_System classes from Smart_City_System)

and then changed the main method of Hospital System to only something like  HospitalEntry( class).
StartHospital() ( method ).Wait() ( Wait because async was the method type for hospital system's main method); 

then changed the .csroj file of hospital for containing <OutputType>Librar</OutputType> instead of <OutputType>Exe</OutputType>

*/
// run using dotnet run --project Smart_City_System/Smart_City_System.csproj

namespace SmartCitySmartCity
{
    class Program
    {
        static void Main(string[] args)
        {
            ICitizenRepository repository = new CitizenRepository();
            CitizenFileRepository fileRepo = new CitizenFileRepository();

            ServiceManager serviceManager = new ServiceManager();
            ServiceMenu serviceMenu = new ServiceMenu(serviceManager);

            CitizenService citizenService = new CitizenService(repository, fileRepo);

            CitizenMenu citizenMenu = new CitizenMenu(citizenService);

            DataMenu dataMenu = new DataMenu();
            SystemMenu systemMenu = new SystemMenu();
            ReportMenu reportMenu = new ReportMenu();

            // Only ONE ServiceMenu instance
            MainMenu mainMenu = new MainMenu(citizenMenu, serviceMenu, dataMenu, systemMenu, reportMenu);

            // Load saved citizens
            var savedCitizens = fileRepo.LoadAll();
            foreach (var citizen in savedCitizens)
            {
                repository.Add(citizen);
            }

            mainMenu.Show();
        }
    }
}
