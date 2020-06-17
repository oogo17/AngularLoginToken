using System.Threading.Tasks;
using auth_api.Data;
using auth_api.Dtos;
using auth_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace auth_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            _repo = repo;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto) {

            userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();

            if ( await _repo.UserExists(userForRegisterDto.UserName))
                return BadRequest("Username already exists");


            var userToCreate = new Users {
              UserName = userForRegisterDto.UserName,
        
            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);

        }
    }
}