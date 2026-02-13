namespace Entities
{
    public class PendingBill
    {
        public int AppointmentId { get; set; }
        public int VisitId { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public decimal AmountDue { get; set; }
        public DateTime VisitDate { get; set; }
    }

    public class FinancialReportRow
    {
        public int BillId { get; set; }
        public string PatientName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentMode { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}