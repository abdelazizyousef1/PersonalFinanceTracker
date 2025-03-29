using Personal_Finance_Tracker.Infrastructure.FinanceDbContext;
using Personal_Finance_Tracker.Infrastructure.Repository;
using Personal_Finance_Tracker.Infrastructure.Repository.IRepository;

namespace Personal_Finance_Tracker.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FinanceContext _financeContext;
        public IUserRepository UserRepo { get; private set; }
        public ITransactionRepository TransactionRepo { get; private set; }

        public UnitOfWork(FinanceContext financeContext) 
        {
            _financeContext = financeContext;
            this.UserRepo = new UserRepository(_financeContext);
            this.TransactionRepo = new TransactionRepository(_financeContext);
        }

        public void SaveAsync()
        {
            _financeContext.SaveChangesAsync();
        }
    }
}
