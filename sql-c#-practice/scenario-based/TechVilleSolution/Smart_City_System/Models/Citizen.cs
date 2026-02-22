// File: Models/Citizen.cs

using System;
using SmartCitySmartCity.Core;

namespace SmartCitySmartCity.Models
{
    public class Citizen : ICityEntity
    {
        public Guid Id { get; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public int Age { get; }
        public double Income { get; private set; }
        public int ResidencyYears { get; }
        public double EligibilityScore { get; private set; }
        public string EligibilityCategory { get; private set; }

        public Citizen(string name, string email, int age, double income, int residencyYears)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Age = age;
            Income = income;
            ResidencyYears = residencyYears;

            RecalculateEligibility();
        }

        public void UpdateIncome(double newIncome)
        {
            Income = newIncome;
            RecalculateEligibility();
        }

        private void RecalculateEligibility()
        {
            EligibilityScore = (Age * 0.3) + (Income * 0.4) + (ResidencyYears * 0.3);
            EligibilityCategory = DetermineCategory();
        }

        private string DetermineCategory()
        {
            if (EligibilityScore < 1000)
                return "Basic";
            else if (EligibilityScore < 5000)
                return "Silver";
            else if (EligibilityScore < 10000)
                return "Gold";
            else
                return "Platinum";
        }

        // Clean object print representation
        public override string ToString()
        {
            return $"Citizen: {Name} | Email: {Email} | Category: {EligibilityCategory}";
        }

        // Logical equality by Email (unique identity rule)
        public override bool Equals(object obj)
        {
            if (obj is not Citizen other)
                return false;

            return this.Email.Equals(other.Email, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return Email.ToLower().GetHashCode();
        }
    }
}
