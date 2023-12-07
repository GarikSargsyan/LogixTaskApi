using LogixTaskApi.Models;
using LogixTaskApi.Models.RequestModels;
using LogixTaskApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogixTaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin,user")]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<List<UserInfo>> GetAllUsers()
        {
            var users = await userRepository.GetUsers();
            return users;
        }

        [HttpGet]
        [Route("GetUserById")]
        public async Task<UserInfo> GetUserById([FromRoute] Guid userId)
        {
            var user = await userRepository.GetUserById(userId);
            return user;
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid userId)
        {
            var successed = await userRepository.DeleteUser(userId);
            if (successed)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequestModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var successed = await userRepository.UpdateUser(user);
            if (!successed)
                return BadRequest();

            return Ok();
        }
    }
}
