using LoanGeteway.Models;
using Microsoft.AspNetCore.Mvc;


namespace LoanGeteway.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<List<Product>, string>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string, List<ErrorDetail>>), 400)]
        [ProducesResponseType(typeof(ApiResponse<string, List<ErrorDetail>>), 500)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = new List<Product> {
                    new Product{Code="auto",Type="AUTO Loan", Description="Applicable for automobile loan" }
                    };
                

                return Ok(ApiResponse<List<Product>, string>.SuccessObject(products, "Products retrieved successfully"));
            }
            catch (Exception ex)
            {
                var error = new List<ErrorDetail>
                    {
                        new ErrorDetail { ErrorCode = "500", Message = "test error" }
                    };
                return StatusCode(500,ApiResponse<string, List<ErrorDetail>>.ErrorObject(error));
            }
 
        }

      
        [HttpPost("products/{productCode}/eligibility")]
        [ProducesResponseType(typeof(ApiResponse<EligibilityCheckResponse, string>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string, List<ErrorDetail>>), 400)]
        [ProducesResponseType(typeof(ApiResponse<string, List<ErrorDetail>>), 500)]
        public async Task<IActionResult> Get([FromBody] EligibilityCheck data)
        {

            try
            {
                var respData = new EligibilityCheckResponse
                {
                    Status = "PartialEligible",
                    Remarks = "Eligibility partially confirmed. Further verification required.",
                    Amount = 1000000
                };

                return Ok(ApiResponse<EligibilityCheckResponse, string>.SuccessObject(respData, "Products retrieved successfully"));
            }
            catch (Exception ex)
            {
                var error = new List<ErrorDetail>
                {
                   new ErrorDetail { ErrorCode = "500", Message = "test error" }
                };
                return StatusCode(500, ApiResponse<string, List<ErrorDetail>>.ErrorObject(error));
            }
        }


        [HttpPost("products/{productCode}/apply")]
        [ProducesResponseType(typeof(ApiResponse<LoanApplicationResponse, string>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string, List<ErrorDetail>>), 400)]
        [ProducesResponseType(typeof(ApiResponse<string, List<ErrorDetail>>), 500)]
        public async Task<IActionResult> Post([FromForm] LoanApplication data)
        {
            try
            {
                var respData = new LoanApplicationResponse
                {
                    Status = "SUBMITTED",
                    Remarks = "You loan application has been submitted.",
                    Arn = "ARNL0011",
                    UserId="USERSSN"
                };

                return Ok(ApiResponse<LoanApplicationResponse, string>.SuccessObject(respData, ""));
            }
            catch (Exception ex)
            {
                var error = new List<ErrorDetail>
                {
                   new ErrorDetail { ErrorCode = "500", Message = "test error" }
                };
                return StatusCode(500, ApiResponse<string, List<ErrorDetail>>.ErrorObject(error));
            }
        }

        [HttpGet("{userid}/{arn}/Status")]
        [ProducesResponseType(typeof(ApiResponse<LoanStatusResponse, string>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string, List<ErrorDetail>>), 400)]
        [ProducesResponseType(typeof(ApiResponse<string, List<ErrorDetail>>), 500)]
        public async Task<IActionResult> Put(string userid, string arn)
        {
            try
            {
                var respData = new LoanStatusResponse
                {
                    Status = "INREVIEW",
                    Remarks = "You loan application is in review process.",
                    Arn = "ARNL0011",
                    UserId = "USERSSN",
                    PendingSteps = new List<string> { },
                    CompletedSteps = new List<string> { },

                };

                return Ok(ApiResponse<LoanStatusResponse, string>.SuccessObject(respData, ""));
            }
            catch (Exception ex)
            {
                var error = new List<ErrorDetail>
                {
                   new ErrorDetail { ErrorCode = "500", Message = "test error" }
                };
                return StatusCode(500, ApiResponse<string, List<ErrorDetail>>.ErrorObject(error));
            }
        }

        //// DELETE api/<LoanController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
