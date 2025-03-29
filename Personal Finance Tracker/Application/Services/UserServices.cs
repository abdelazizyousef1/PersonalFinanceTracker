using Personal_Finance_Tracker.Application.IServices;
using Personal_Finance_Tracker.Infrastructure.UnitOfWork;
using Personal_Finance_Tracker.Domin;
namespace Personal_Finance_Tracker.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUnitOfWork _unit;
        
        public UserServices(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task AddUser(string name)
        {
            var user = new User { Name = name };
           await _unit.UserRepo.AddUserAsync(user);
            

        }
        public async Task<User> GetUser(int id)
        {
            return await _unit.UserRepo.GetUserAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await _unit.UserRepo.GetAllUserAsync();
        }
        public async Task DeleteUser(int Id)
        {
            await _unit.UserRepo.DeleteUserAsync(Id);
            _unit.SaveAsync();
        }
    }
}
