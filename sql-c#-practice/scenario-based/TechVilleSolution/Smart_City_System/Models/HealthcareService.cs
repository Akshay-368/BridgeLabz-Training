using System;
using SmartCitySmartCity.Core;

namespace SmartCitySmartCity.Models
{
    public class HealthcareService : Service, IBookable, ICancellable, ITrackable
    {
        public bool EmergencySupport { get; }
        private string _status = "Available";

        public HealthcareService(double baseCost, bool emergencySupport)
            : base("Healthcare Service", baseCost)
        {
            EmergencySupport = emergencySupport;
        }

        public override void DisplayServiceInfo()
        {
            base.DisplayServiceInfo();
            Console.WriteLine($"Emergency Support: {EmergencySupport}");
            Console.WriteLine($"Status: {_status}");
        }

        public void BookService(string citizenName)
        {
            _status = $"Booked by {citizenName}";
        }

        public void CancelService(string citizenName)
        {
            _status = "Available";
        }

        public string GetStatus()
        {
            return _status;
        }
    }
}
