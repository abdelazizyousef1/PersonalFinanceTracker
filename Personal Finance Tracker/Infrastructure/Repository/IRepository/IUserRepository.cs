using Personal_Finance_Tracker.Domin;
using System.Threading.Tasks;

namespace Personal_Finance_Tracker.Infrastructure.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);
        Task<User> GetUserAsync(int Id);

        Task<ICollection<User>> GetAllUserAsync();   
        Task DeleteUserAsync(int Id);
        Task UpdateUsersBalance(int senderId, int ReceiverId, double amount);
    }
}
