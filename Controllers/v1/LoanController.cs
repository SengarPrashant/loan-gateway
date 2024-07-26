﻿using LoanGateway.Models;
using LoanGateway.Services;
using LoanGatewayShared.Models;
using Microsoft.AspNetCore.Mvc;


namespace LoanGeteway.Controllers.v1
{
	[Route("api/v1/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;
        public LoanController(ILoanService loanService) {
        _loanService = loanService;
        }
        
        [HttpGet("products")]
        [ProducesResponseType(typeof(ApiResponse<List<Product>, string>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string, List<ErrorDetail>>), 400)]
        [ProducesResponseType(typeof(ApiResponse<string, List<ErrorDetail>>), 500)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = _loanService.GetProductsList();

                return Ok(ApiResponse<List<Product>, string>.SuccessObject(products, Message.Success));
            }
            catch (Exception ex)
            {
                var error = new List<ErrorDetail>
                    {
                        new ErrorDetail { ErrorCode = "500", Message =Message.UnknownError }
                    };
                return StatusCode(500,ApiResponse<string, List<ErrorDetail>>.ErrorObject(error));
            }
 
        }

      
        [HttpPost("products/{productCode}/eligibility")]
        [ProducesResponseType(typeof(ApiResponse<EligibilityCheckResponse, string>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string, List<ErrorDetail>>), 400)]
        [ProducesResponseType(typeof(ApiResponse<string, List<ErrorDetail>>), 500)]
        public async Task<IActionResult> Eligibility(string productCode, [FromBody] EligibilityCheck request)
        {
            try
            {
                var reqId = Guid.NewGuid();
                request.RequestId = reqId;

                var result = _loanService.EligibilityCheck(productCode,request);

                return Ok(ApiResponse<EligibilityCheckResponse, string>.SuccessObject(result, Message.Success));
            }
            catch (Exception ex)
            {
                var error = new List<ErrorDetail>
                {
                   new ErrorDetail { ErrorCode = "500", Message = Message.UnknownError }
                };
                return StatusCode(500, ApiResponse<string, List<ErrorDetail>>.ErrorObject(error));
            }
        }


        [HttpPost("products/{productCode}/apply")]
        [ProducesResponseType(typeof(ApiResponse<LoanApplicationResponse, string>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string, List<ErrorDetail>>), 400)]
        [ProducesResponseType(typeof(ApiResponse<string, List<ErrorDetail>>), 500)]
        public async Task<IActionResult> Apply(string productCode, [FromForm] LoanApplication request)
        {
            try
            {
                var result = _loanService.SubmitApplication(productCode, request);

                return Ok(ApiResponse<LoanApplicationResponse, string>.SuccessObject(result, Message.Success));
            }
            catch (Exception ex)
            {
                var error = new List<ErrorDetail>
                {
                   new ErrorDetail { ErrorCode = "500", Message = Message.UnknownError }
                };
                return StatusCode(500, ApiResponse<string, List<ErrorDetail>>.ErrorObject(error));
            }
        }

        [HttpGet("{userid}/{arn}/Status")]
        [ProducesResponseType(typeof(ApiResponse<LoanStatusResponse, string>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string, List<ErrorDetail>>), 400)]
        [ProducesResponseType(typeof(ApiResponse<string, List<ErrorDetail>>), 500)]
        public async Task<IActionResult> Status(string userid, string arn)
        {
            try
            {
                var result = _loanService.GetStatus(userid, arn);

                return Ok(ApiResponse<LoanStatusResponse, string>.SuccessObject(result, Message.Success));
            }
            catch (Exception ex)
            {
                var error = new List<ErrorDetail>
                {
                   new ErrorDetail { ErrorCode = "500", Message = Message.UnknownError }
                };
                return StatusCode(500, ApiResponse<string, List<ErrorDetail>>.ErrorObject(error));
            }
        }

        [HttpGet("{userid}/history")]
        [ProducesResponseType(typeof(ApiResponse<LoanStatusResponse, string>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string, List<ErrorDetail>>), 400)]
        [ProducesResponseType(typeof(ApiResponse<string, List<ErrorDetail>>), 500)]
        public async Task<IActionResult> History(string userid)
        {
            try
            {
                var result = _loanService.GetHistory(userid);

                return Ok(ApiResponse<UserRequestHistory, string>.SuccessObject(result, Message.Success));
            }
            catch (Exception ex)
            {
                var error = new List<ErrorDetail>
                {
                   new ErrorDetail { ErrorCode = "500", Message = Message.UnknownError }
                };
                return StatusCode(500, ApiResponse<string, List<ErrorDetail>>.ErrorObject(error));
            }
        }
    }
}
