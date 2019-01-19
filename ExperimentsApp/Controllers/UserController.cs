using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ExperimentsApp.Data.Dto;
using ExperimentsApp.Data.Model;
using ExperimentsApp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ExperimentsApp.API.Controllers
{
    [Authorize]
    [Route("/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]UserLogin userLogin)
        {
            var user = await _userService.FindUserByUsernameAsync(userLogin.Username);
            if (user == null)
                return BadRequest("User not found");
            
            if(!_userService.AuthenticateUser(user, userLogin.Password))
                return BadRequest("Incorrect username or password");

            var authenticatedUser = _userService.GenerateToken(user);
            return Ok(authenticatedUser);
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserRegistration userRegistration)
        {
            if (await _userService.FindUserByUsernameAsync(userRegistration.Username) != null)
                return BadRequest("This username is already taken");

            if (string.IsNullOrWhiteSpace(userRegistration.Password))
                return BadRequest("Password is required");

            var user = _mapper.Map<User>(userRegistration);

            await _userService.CreateUserAsync(user, userRegistration.Password);
            if (!await _userService.SaveChangesAsync())
                return StatusCode(500, "A problem with saving user");

            return Ok("Registration completed successfully");
        }

        


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetUsersAsync();
            var userDtos = _mapper.Map<IList<UserDisplay>>(users);
            return Ok(userDtos);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetById(int userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
                return BadRequest("User not found");

            var userDto = _mapper.Map<UserDisplay>(user);
            return Ok(userDto);
        }


        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.Name));
            if (currentUserId != userId)
                return Unauthorized();

            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
                return BadRequest("User not found");

            await _userService.DeleteUserAsync(user);

            if (!await _userService.SaveChangesAsync())
                return StatusCode(500, "A problem with saving changes");
            
            return NoContent();
        }   
    }
}
