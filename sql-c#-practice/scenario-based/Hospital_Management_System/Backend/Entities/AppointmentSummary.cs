namespace Entities;
using System;
// A lightweight class for the Appointment "List View" for the Receptionist and doctor
public class AppointmentSummary
{
    public int Id { get; set; }
    public string PatientName { get; set; } = string.Empty;
    public string DoctorName { get; set; } = string.Empty;
    public DateTime AppointmentDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
}
