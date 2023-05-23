using Finance.Application.UseCases.CreateTransaction;
using Finance.Application.UseCases.GetAllTransactions;
using Finance.Application.UseCases.GetDailyTransactions;
using Finance.Application.UseCases.GetTransaction;
using Finance.Application.UseCases.RemoveTransaction;
using Finance.Application.UseCases.UpdateTransaction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : Controller
    {
        private readonly IMediator _mediator;
        public ReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

      
        [HttpGet("Daily")]
        public async Task<ActionResult> GetDaily([FromQuery]GetDailyTransactionsInput input)
        {
            var result = await _mediator.Send(input);
            if (!result.IsValid)
                return BadRequest("Get daily transaction is invalid!");

            return Ok(result);
        }
    }
}
