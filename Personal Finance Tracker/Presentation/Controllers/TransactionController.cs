using Microsoft.AspNetCore.Mvc;
using Personal_Finance_Tracker.Application.IServices;
using Personal_Finance_Tracker.Domin;

namespace Personal_Finance_Tracker.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController :ControllerBase
    {
        private readonly ITransactionServices _transactionServices;

        public TransactionController(ITransactionServices transactionServices)
        {
            _transactionServices = transactionServices;
        }

        [HttpPost]
        [Route("AddTransaction")]
        public async Task<IActionResult> NewTransaction(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("");
            }
            try
            {
                await _transactionServices.AddTransaction(transaction);
                return Ok(201);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetTransaction")]
        public async Task<Transaction> GetTransaction(int Id)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("");
            }
            try
            {
                var transaction = await _transactionServices.GetTransaction(Id);
                return (transaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpGet]
        [Route("GetAllTransaction")]
        public async Task<IEnumerable<Transaction>> GetAllTransaction()
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("");
            }
            try
            {
                var transactions = await _transactionServices.GetAllTransaction();
                return (transactions);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpGet]
        [Route("DeleteTransaction")]
        public async Task<IActionResult> DeleteTransaction(int Id)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("");
            }
            try
            {
                 await _transactionServices.DeleteTransaction(Id);
                return Ok(200);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
