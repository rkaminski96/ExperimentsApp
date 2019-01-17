using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ExperimentsApp.API.Helpers;
using ExperimentsApp.Data.Dto;
using ExperimentsApp.Data.Model;
using ExperimentsApp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ExperimentsApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private AppSettings _appSettings;

        public UserController(IUserService userService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]UserDto userDto)
        {
            var user = await _userService.FindUserByUsernameAsync(userDto.Username);
            if (user == null)
                return BadRequest("User not found");
            
            if(!_userService.AuthenticateUser(user, userDto.Password))
                return BadRequest("Incorrect username or password");


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
               {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
               }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString
            });
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserRegistrationDto userRegistrationDto)
        {
            if (await _userService.FindUserByUsernameAsync(userRegistrationDto.Username) != null)
                return BadRequest("This username is already taken");

            if (string.IsNullOrWhiteSpace(userRegistrationDto.Password))
                return BadRequest("Password is required");

            var user = _mapper.Map<User>(userRegistrationDto);

            await _userService.CreateUserAsync(user, userRegistrationDto.Password);
            if (!await _userService.SaveChangesAsync())
                return StatusCode(500, "A problem with saving user");

            return Ok("Registration completed successfully");
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetUsersAsync();
            var userDtos = _mapper.Map<IList<UserDto>>(users);
            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return BadRequest("User not found");

            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return BadRequest("User not found");

            await _userService.DeleteUserAsync(user);

            if (!await _userService.SaveChangesAsync())
                return StatusCode(500, "A problem with saving changes");
            
            return NoContent();
        }   
    }
}
