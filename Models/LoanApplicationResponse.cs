namespace LoanGateway.Models
{
	public class LoanApplicationResponse
    {
        public string Arn { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public double Amount { get; set; }
        public int TenureMonths { get; set; }
        public double InterestRate { get; set; }
    }
}
