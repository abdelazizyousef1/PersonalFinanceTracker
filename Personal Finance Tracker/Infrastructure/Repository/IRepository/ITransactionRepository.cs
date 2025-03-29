using Personal_Finance_Tracker.Domin;
using Personal_Finance_Tracker.Infrastructure.FinanceDbContext;

namespace Personal_Finance_Tracker.Infrastructure.Repository.IRepository
{
    public interface ITransactionRepository
    {
        Task AddTransactionAsync(Transaction transaction);

        Task<Transaction> GetTransactionAsync(int Id);

        Task<ICollection<Transaction>> GetAllTransactionAsync();
       
        Task DeleteTransactionAsync(int Id);
    }
}
