using Personal_Finance_Tracker.Infrastructure.FinanceDbContext;
using Personal_Finance_Tracker.Domin;
namespace Personal_Finance_Tracker.Application.IServices
{
    public interface ITransactionServices
    {
         Task AddTransaction(Transaction transaction);
        Task<Transaction> GetTransaction(int id);

        Task<IEnumerable<Transaction>> GetAllTransaction();
        Task DeleteTransaction(int Id);
    }
}
