namespace LoanGateway.Models
{
	public class EligibilityCheckResponse
    {
        public Guid RequestId { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public double InterestRate { get; set; }
        public double Emi { get; set; }
    }
}
