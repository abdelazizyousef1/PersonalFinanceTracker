using Microsoft.AspNetCore.Mvc;
using Personal_Finance_Tracker.Application.IServices;
using Personal_Finance_Tracker.Application.Services;
using Personal_Finance_Tracker.Domin;

namespace Personal_Finance_Tracker.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task NewUser(string name)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("user not added");
            }
            try
            {
                await _userServices.AddUser(name);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetUser")]
        public async Task<User> GetUser(int Id)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("");
            }
            try
            {
                var user = await _userServices.GetUser(Id);
                return (user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IEnumerable<User>> GetAllUser()
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("");
            }
            try
            {
                var users = await _userServices.GetAllUser();
                return (users);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpGet]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("");
            }
            try
            {
                await _userServices.DeleteUser(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
