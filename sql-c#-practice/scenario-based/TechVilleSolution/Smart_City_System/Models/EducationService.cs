using System;
using SmartCitySmartCity.Core;

namespace SmartCitySmartCity.Models
{
    public class EducationService : Service, IBookable, ICancellable, ITrackable
    {
        public string CourseType { get; }
        private string _status = "Available";

        public EducationService(double baseCost, string courseType)
            : base("Education Service", baseCost)
        {
            CourseType = courseType;
        }

        public override void DisplayServiceInfo()
        {
            base.DisplayServiceInfo();
            Console.WriteLine($"Course Type: {CourseType}");
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
