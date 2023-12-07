using LogixTaskApi.Models.RequestModels;
using LogixTaskApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LogixTaskApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignInController : Controller
    {
        private readonly ISignInRepository _signInRepository;
        public SignInController(ISignInRepository signInRepository)
        {
            _signInRepository = signInRepository;
        }

        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> SignIn(SignInRequestModel userModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _signInRepository.SignIn(userModel);

            if (result == null)
                return BadRequest(string.Empty);

            return Ok(result);
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> Registration(RegistrationRequestModel userModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var token = await _signInRepository.Registration(userModel);

            if (token == null)
                return BadRequest(string.Empty);

            return Ok(token);
        }
    }
}
