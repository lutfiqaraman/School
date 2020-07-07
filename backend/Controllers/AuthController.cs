
using System.Threading.Tasks;
using backend.Data;
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
    public async Task<IActionResult> Register(string username, string password)
    {
      username = username.ToLower();

      if (await _repo.IsUserExist(username))
        return BadRequest("User is already exist");
      
      User userToBeCreated = new User {
        UserName = username
      };

      var createdUser = await _repo.Register(userToBeCreated, password);
      return StatusCode(201);
    }

  }
}