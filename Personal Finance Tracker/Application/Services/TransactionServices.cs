using Personal_Finance_Tracker.Application.IServices;
using Personal_Finance_Tracker.Domin;
using Personal_Finance_Tracker.Infrastructure.UnitOfWork;

namespace Personal_Finance_Tracker.Application.Services
{
    public class TransactionServices : ITransactionServices
    {
        private readonly IUnitOfWork _unit;

        public TransactionServices(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task AddTransaction(Transaction transaction)
        {
            await _unit.UserRepo.UpdateUsersBalance(transaction.UserId, transaction.ReceiverId, transaction.Amount);
            await _unit.TransactionRepo.AddTransactionAsync(transaction);
            _unit.SaveAsync();

        }
        public async Task<Transaction> GetTransaction(int id)
        {
            return await _unit.TransactionRepo.GetTransactionAsync(id);
        }

        public async Task<IEnumerable<Transaction>> GetAllTransaction()
        {
            return await _unit.TransactionRepo.GetAllTransactionAsync();
        }
        public async Task DeleteTransaction(int Id)
        {
            await _unit.TransactionRepo.DeleteTransactionAsync(Id);
            _unit.SaveAsync();
        }
    }
}
