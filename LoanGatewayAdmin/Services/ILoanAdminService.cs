using LoanGatewayShared.Models;

namespace LoanGatewayAdmin.Services
{
	public interface ILoanAdminService
	{

		Task<List<LoanApplication>> GetLoanApplicationsAsync();

		void UpdateStatus(string arn, string status, double amount);

	}
}
