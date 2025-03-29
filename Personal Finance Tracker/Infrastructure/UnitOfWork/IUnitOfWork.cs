using Personal_Finance_Tracker.Infrastructure.Repository.IRepository;

namespace Personal_Finance_Tracker.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
         IUserRepository UserRepo { get; }
         ITransactionRepository TransactionRepo { get;}
         void SaveAsync();
    }
}
