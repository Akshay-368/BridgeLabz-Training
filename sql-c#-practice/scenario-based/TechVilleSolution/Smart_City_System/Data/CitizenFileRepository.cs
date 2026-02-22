// File: Data/CitizenFileRepository.cs

using System;
using System.Collections.Generic;
using System.IO;
using SmartCitySmartCity.Models;

namespace SmartCitySmartCity.Data
{
    // Handles file-based persistence for citizens
    public class CitizenFileRepository
    {
        private readonly string _filePath = "citizens.txt";

        public void SaveAll(List<Citizen> citizens)
        {
            using var writer = new StreamWriter(_filePath, false);

            foreach (var citizen in citizens)
            {
                string line = $"{citizen.Name}|{citizen.Email}|{citizen.Age}|{citizen.Income}|{citizen.ResidencyYears}";
                writer.WriteLine(line);
            }
        }

        public List<Citizen> LoadAll()
        {
            var citizens = new List<Citizen>();

            if (!File.Exists(_filePath))
                return citizens;

            var lines = File.ReadAllLines(_filePath);

            foreach (var line in lines)
            {
                var parts = line.Split('|');

                if (parts.Length == 5)
                {
                    var citizen = new Citizen(
                        parts[0],
                        parts[1],
                        int.Parse(parts[2]),
                        double.Parse(parts[3]),
                        int.Parse(parts[4])
                    );

                    citizens.Add(citizen);
                }
            }

            return citizens;
        }
    }
}
