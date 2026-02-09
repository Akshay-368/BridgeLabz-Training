namespace Entities;
// A lightweight class specifically for the Receptionist's "List View"
    public class PatientSummary
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
    }
