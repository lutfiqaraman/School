
using System.Threading.Tasks;
using backend.Data;
using backend.Dtos;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AuthController : ControllerBase
  {
    private readonly IAuthRepository _repo;
    public AuthController(IAuthRepository repo)
    {
      _repo = repo;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserForRegisterDto userForRegister)
    {

      userForRegister.UserName = userForRegister.UserName.ToLower();

      if (await _repo.IsUserExist(userForRegister.UserName))
        return BadRequest("User is already exist");
      
      User userToBeCreated = new User {
        UserName = userForRegister.UserName
      };

      var createdUser = await _repo.Register(userToBeCreated, userForRegister.Password);
      return StatusCode(201);
    }

  }
}