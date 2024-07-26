using LoanGatewayShared.Models;

namespace LoanGatewayAdmin.Services
{
	public class LoanAdminService : ILoanAdminService
	{
		public Task<List<LoanApplication>> GetLoanApplicationsAsync()
		{
			var applications = new List<LoanApplication>();

			// TBD get from DB
			

			return Task.FromResult(applications);
		}

		public void UpdateStatus(string arn, string status, double amount)
		{
			// To get from DB and then update

			throw new NotImplementedException();
		}
	}
}
