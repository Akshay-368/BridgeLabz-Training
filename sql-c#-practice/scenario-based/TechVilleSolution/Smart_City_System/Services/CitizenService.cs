// File: Services/CitizenService.cs

using System;
using System.Collections.Generic;
using SmartCitySmartCity.Data;
using SmartCitySmartCity.Models;
using SmartCitySmartCity.Utilities;
using SmartCitySmartCity.Exceptions;

namespace SmartCitySmartCity.Services
{
    public class CitizenService
    {
        private readonly ICitizenRepository _repository;
        private readonly CitizenFileRepository _fileRepository;

        public CitizenService(
            ICitizenRepository repository,
            CitizenFileRepository fileRepository)
        {
            _repository = repository;
            _fileRepository = fileRepository;
        }

        public void RegisterCitizen(
            string name,
            string email,
            int age,
            double income,
            int residencyYears,
            int zone,
            int sector)
        {
            ValidationHelper.ValidateAge(age);
            ValidationHelper.ValidateIncome(income);

            name = StringHelper.FormatName(name);

            if (!StringHelper.IsValidEmail(email))
                throw new ArgumentException("Invalid email format.");

            var existingCitizen = SearchByName(name);
            if (existingCitizen != null)
                throw new DuplicateCitizenException("Citizen already exists.");

            var citizen = new Citizen(name, email, age, income, residencyYears);

            _repository.Add(citizen);

            // Save immediately after adding
            _fileRepository.SaveAll(_repository.GetAll());
        }

        public Citizen SearchByName(string name)
        {
            var citizens = _repository.GetAll();

            foreach (var citizen in citizens)
            {
                if (citizen.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return citizen;
            }

            return null;
        }

        public void UpdateCitizenIncome(string name, double newIncome)
        {
            var citizen = SearchByName(name);

            if (citizen == null)
                throw new Exception("Citizen not found.");

            citizen.UpdateIncome(newIncome);

            // Save after update
            _fileRepository.SaveAll(_repository.GetAll());
        }

        public void DisplayAllCitizens()
        {
            var citizens = _repository.GetAll();

            if (citizens.Count == 0)
            {
                Console.WriteLine("No citizens registered.");
                return;
            }

            foreach (var citizen in citizens)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine($"Name: {citizen.Name}");
                Console.WriteLine($"Email: {citizen.Email}");
                Console.WriteLine($"Age: {citizen.Age}");
                Console.WriteLine($"Income: {citizen.Income}");
                Console.WriteLine($"Residency: {citizen.ResidencyYears}");
                Console.WriteLine($"Score: {citizen.EligibilityScore:F2}");
                Console.WriteLine($"Category: {citizen.EligibilityCategory}");
            }
        }

        public List<Citizen> GetAllCitizens()
        {
            return _repository.GetAll();
        }
    }
}
