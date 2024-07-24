using LoanGeteway.Common;
using LoanGeteway.Models;

namespace LoanGeteway.Services
{
    public class LoanService : ILoanService
    {
        public List<Product> GetProductsList()
        {
            var products = new List<Product> {
                     new Product{Code="A0001",Type="AUTO Loan", Description="Applicable for automobile loan" },
                     new Product{Code="H0001",Type="Home Loan", Description="Applicable for home loan" },
                     new Product{Code="P0001",Type="Personal Loan", Description="Applicable for personal loan" },
                     new Product{Code="S0001",Type="Student Loan", Description="Applicable for student loan" },
                    };

            return products;
        }
        public EligibilityCheckResponse EligibilityCheck(string loanType, EligibilityCheck request)
        {
            var (interestRate, emi) = LoanCalculator.CalculateInterestRateAndEMI(loanType,request);

            request.Emi = emi;
            request.InterestRate = interestRate;

            // save to DB

            // returning the response
            return new EligibilityCheckResponse
            {
                InterestRate = interestRate,
                Emi = emi,
                Amount = request.Amount,
                Status = "Eligible",
                Remarks = "",
                RequestId = (Guid)request.RequestId
            };
        }

        public LoanApplicationResponse SubmitApplication(string loanType, LoanApplication request)
        {
            var eligibility = new EligibilityCheck { AnnualIncome=request.AnnualIncome, Occupation=request.Occupation, Amount=request.Amount, Dob=request.Dob };
            var (interestRate, emi) = LoanCalculator.CalculateInterestRateAndEMI(loanType,eligibility);

            request.Arn = $"{loanType.ToUpper().Substring(0, 1)}{DateTime.Now.Ticks}"; // generating unique ARN
            request.Emi = emi;
            request.InterestRate = interestRate;

            // save to DB


            // return  the response
            return new LoanApplicationResponse { 
                Arn = request.Arn,
                Amount = request.Amount,
                InterestRate = interestRate,
                Status =Status.Submitted,
                Remarks = "",
                TenureMonths = request.TenureMonths,
                UserId=request.Ssn
            };
        }


        public LoanStatusResponse GetStatus(string userId, string arn)
        {
           var result = new LoanStatusResponse
           {
               Status = Status.InReview,
               Remarks = "You loan application is in review process.",
               Arn = arn,
               UserId = userId,
               PendingSteps = new List<string> { },
               CompletedSteps = new List<string> { },
           };

            return result;
        }

        public UserRequestHistory GetHistory(string userId)
        {
            var result = new UserRequestHistory {
                EligibilityChecks=new List<EligibilityCheck> { }, // this will be fetched from database
                LoanApplications=new List<LoanApplication> { } // this will be fetched from database
            };
            return result;
        }
    }
}
