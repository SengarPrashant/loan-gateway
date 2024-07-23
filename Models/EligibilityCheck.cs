namespace LoanGeteway.Models
{
    public class EligibilityCheck
    {
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string SSN { get; set; }
        public DateTime Dob { get; set; }
        public double Amount { get; set; }
    }
    public class EligibilityCheckResponse
    {
        public double Amount { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
    }
}
