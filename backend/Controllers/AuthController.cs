
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using backend.Data;
using backend.Dtos;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace backend.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AuthController : ControllerBase
  {
    private readonly IAuthRepository _repo;
    private readonly IConfiguration _config;

    public AuthController(IAuthRepository repo, IConfiguration config)
    {
      _repo = repo;
      _config = config;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserForRegisterDto userForRegister)
    {

      userForRegister.UserName = userForRegister.UserName.ToLower();

      if (await _repo.IsUserExist(userForRegister.UserName))
        return BadRequest("User is already exist");

      User userToBeCreated = new User
      {
        UserName = userForRegister.UserName
      };

      var createdUser = await _repo.Register(userToBeCreated, userForRegister.Password);
      return StatusCode(201);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserForLoginDto userForLogin)
    {
      User user = await _repo.Login(userForLogin.Username.ToLower(), userForLogin.Password);

      if (user == null)
        return Unauthorized();

      Claim[] claims = new[]
      {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.NameIdentifier, user.UserName)
      };

      SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                      _config.GetSection("AppSettings:Token").Value));

      SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
      SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.Now.AddDays(1),
        SigningCredentials = creds
      };

      JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
      SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
      
      return Ok(new {
        token = tokenHandler.WriteToken(token)
      });
    }
  }
}