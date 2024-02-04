﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TasksAPI.Models.DTO;
using TasksAPI.Repositories;

namespace TasksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager,ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
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

                 var jwtToken =  _tokenRepository.CreateJWTToken(user);

                    var response = new LoginResponseDTO
                    {
                        JwtToken = jwtToken
                    };
                    return Ok(response);
                }
            }
          
                return BadRequest("username or password incorrect.");
            
        }
    } 
}
 