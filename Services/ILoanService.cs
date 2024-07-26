using LoanGateway.Models;
using LoanGatewayShared.Models;

namespace LoanGateway.Services
{
    public interface ILoanService
    {
        List<Product> GetProductsList();
        EligibilityCheckResponse EligibilityCheck(string productCode, EligibilityCheck request);
        LoanApplicationResponse SubmitApplication(string productCode, LoanApplication request);
        LoanStatusResponse GetStatus(string userId, string arn);
        UserRequestHistory GetHistory(string userId);
    }
}
