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
    public class TransactionController : Controller
    {
        private readonly IMediator _mediator;
        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetTransactionInput(id));

            if(!result.IsValid)
              return BadRequest("Get transaction invalid!");

            if(result.Result is null)
              return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllTransactionsInput());
            if (!result.IsValid)
                return BadRequest("Get all transaction is invalid!");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateTransactionInput input)
        {
            var result = await _mediator.Send(input);
            if (!result.IsValid)
                return BadRequest("Create transaction is invalid!");

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateTransactionInput input)
        {
            var result = await _mediator.Send(input);
            if (!result.IsValid)
                return BadRequest("Update transaction is invalid!");

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            var result = await _mediator.Send(new RemoveTransactionInput(id));
            if (!result.IsValid)
                return BadRequest("Remove transaction is invalid!");

            return Ok();
        }
    }
}
