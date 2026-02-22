// File: Models/Service.cs

using System;
using SmartCitySmartCity.Core;

namespace SmartCitySmartCity.Models
{
    // Abstract base class ensures no direct instantiation
    public abstract class Service : ICityEntity
    {
        public Guid Id { get; }
        public string ServiceName { get; protected set; }
        public double BaseCost { get; protected set; }

        protected static int TotalServicesCreated = 0;

        protected Service(string serviceName, double baseCost)
        {
            this.Id = Guid.NewGuid(); // Ensures unique identity
            this.ServiceName = serviceName;
            this.BaseCost = baseCost;

            TotalServicesCreated++;
        }

        // Overridable for derived customization
        public virtual void DisplayServiceInfo()
        {
            Console.WriteLine(ToString());
        }

        // Improves debugging & logging readability
        public override string ToString()
        {
            return $"Service: {ServiceName} | Cost: {BaseCost}";
        }

        // Defines logical equality based on Id
        public override bool Equals(object obj)
        {
            if (obj is not Service other)
                return false;

            return this.Id.Equals(other.Id);
        }

        // Required when overriding Equals
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static int GetTotalServices()
        {
            return TotalServicesCreated;
        }
    }
}
