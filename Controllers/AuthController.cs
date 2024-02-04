using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TasksAPI.Models.DTO;

namespace TasksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDTO.Username,
                Email = registerRequestDTO.Username
            };
           var identityResult =  await _userManager.CreateAsync(identityUser, registerRequestDTO.Password);

            if (identityResult.Succeeded)
            {
                return Ok("User is Registered! Please login.");
            }
            else
            {
                return BadRequest("something went wrong");
            }
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {

            var user = await _userManager.FindByEmailAsync(loginRequestDTO.Username);

            if(user!= null)
            {
                var checkPasswordResult =  await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
                if (checkPasswordResult)
                {
                    //Create Token



                    return Ok();
                }
            }
          
                return BadRequest("username or password incorrect.");
            
        }
    } 
}
 