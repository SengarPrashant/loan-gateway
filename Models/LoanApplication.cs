namespace LoanGeteway.Models
{
    public class LoanApplication
    {
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Ssn { get; set; }
        public DateTime Dob { get; set; }
        public double Amount { get; set; }
        public IFormFile SsnDocument { get; set; }
        public IFormFile ItrDocument { get; set; }
        public IFormFile? IncomeSlipDocument { get; set; }
        public IFormFile? AadhaarDocument { get; set; }
    }
    public class LoanApplicationResponse
    {
        public string Arn { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
    }
    public class LoanStatusResponse
    {
        public string Arn { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public List<string> CompletedSteps { get; set; }
        public List<string> PendingSteps { get; set; }
    }
}
