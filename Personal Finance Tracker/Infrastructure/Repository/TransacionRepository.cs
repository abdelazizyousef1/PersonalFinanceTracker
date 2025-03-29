using Microsoft.EntityFrameworkCore;
using Personal_Finance_Tracker.Domin;
using Personal_Finance_Tracker.Infrastructure.FinanceDbContext;
using Personal_Finance_Tracker.Infrastructure.Repository.IRepository;

namespace Personal_Finance_Tracker.Infrastructure.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly FinanceContext _financeContext;
        public TransactionRepository(FinanceContext financeContext)
        {
            _financeContext = financeContext;
        }
        public async Task AddTransactionAsync(Transaction transaction)
        {
            
            await _financeContext.Transactions.AddAsync(transaction);
            
        }
        public async Task<Transaction> GetTransactionAsync(int Id)
        {
            var searchedtransaction = await _financeContext.Transactions.FindAsync(Id);
            return searchedtransaction;
        }

        public async Task<ICollection<Transaction>> GetAllTransactionAsync()
        {
            var allTransactions = await _financeContext.Transactions.ToListAsync();
            return allTransactions;
        }
        public async Task DeleteTransactionAsync(int Id)
        {
            var searchedTransaction = await _financeContext.Transactions.FindAsync(Id);
            _financeContext.Transactions.Remove(searchedTransaction);
        }
    }
}
