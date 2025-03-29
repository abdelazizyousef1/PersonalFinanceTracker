using Microsoft.AspNetCore.Mvc;
using Personal_Finance_Tracker.Application.IServices;
using Personal_Finance_Tracker.Application.Services;
using Personal_Finance_Tracker.Domin;

namespace Personal_Finance_Tracker.Presentation.Controllers
{
    [Route(("api/[controller]"))]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(string name)
        {
            
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("name of user not added");
                }
                await _userServices.AddUser(name);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpGet("[id]")]
        public async Task<IActionResult> GetUser(int Id)
        {
            
            try
            {
                if (Id <= 0)
                    return BadRequest("Invalid transaction ID.");
                var user = await _userServices.GetUser(Id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            
            try
            {
                var users = await _userServices.GetAllUser();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }


        [HttpDelete("[id]")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            try
            {
                if (Id <= 0)
                    return BadRequest("Invalid transaction ID.");

                await _userServices.DeleteUser(Id);
                return Ok(new { Message = "Transaction deleted successfully." });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
