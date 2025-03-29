using Personal_Finance_Tracker.Domin;

namespace Personal_Finance_Tracker.Application.IServices
{
    public interface IUserServices
    {
        Task AddUser(string name);
        Task<User> GetUser(int id);

         Task<IEnumerable<User>> GetAllUser();
         Task DeleteUser(int Id);
    }
}
