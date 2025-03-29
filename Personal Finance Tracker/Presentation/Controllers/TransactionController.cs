using Microsoft.AspNetCore.Mvc;
using Personal_Finance_Tracker.Application.IServices;
using Personal_Finance_Tracker.Domin;

namespace Personal_Finance_Tracker.Presentation.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionServices _transactionServices;

        public TransactionController(ITransactionServices transactionServices)
        {
            _transactionServices = transactionServices;
        }


        [HttpPost]
        public async Task<IActionResult> Transfer( Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid transaction data.");
            }

            try
            {
                await _transactionServices.AddTransaction(transaction);
                return StatusCode(201, new { Message = "Transaction added successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid transaction ID.");

                var transaction = await _transactionServices.GetTransaction(id);
                if (transaction == null)
                    return NotFound("Transaction not found.");

                return Ok(transaction);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            try
            {
                var transactions = await _transactionServices.GetAllTransaction();
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid transaction ID.");

                await _transactionServices.DeleteTransaction(id);
                return Ok(new { Message = "Transaction deleted successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}