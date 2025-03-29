using Personal_Finance_Tracker.Domin;
using Personal_Finance_Tracker.Infrastructure.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using Personal_Finance_Tracker.Infrastructure.FinanceDbContext;

namespace Personal_Finance_Tracker.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly FinanceContext _financeContext;
        public UserRepository(FinanceContext financeContext)
        {
            _financeContext = financeContext;
        }



        public async Task<User> AddUserAsync(User user)
        {
            await _financeContext.Users.AddAsync(user);
            await _financeContext.SaveChangesAsync();
            return user;
        }
        public async Task<User> GetUserAsync(int Id)
        {
            var searchedUser= await _financeContext.Users.FindAsync(Id) ;
            return searchedUser;
        }

        public async Task<ICollection<User>> GetAllUserAsync()
        {
            var AllUsers = await _financeContext.Users.ToListAsync();
            return AllUsers;
        }
        public async Task DeleteUserAsync(int Id)
        {
            var searchedUser = await _financeContext.Users.FindAsync(Id);
             _financeContext.Users.Remove(searchedUser);
            await _financeContext.SaveChangesAsync();
        }

        public async Task UpdateUsersBalance(int senderId , int ReceiverId, double amount)
        {
            var sender = await _financeContext.Users.FirstOrDefaultAsync(u=>u.Id == senderId);
            var recever =await _financeContext.Users.FirstOrDefaultAsync(u => u.Id == ReceiverId);
            if (sender == null || recever == null)
            {
                throw new Exception ("sender or recever not found");
            }
            if (sender.Balance > amount)
            {
                sender.Balance -= amount;
                recever.Balance += amount;
                await _financeContext.SaveChangesAsync();
            }
        }
    }
}
