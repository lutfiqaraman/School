using System.Threading.Tasks;
using backend.Models;
using Microsoft.Extensions.Configuration;

namespace backend.Data
{
  public class AuthRepository : IAuthRepository
  {
    private readonly IConfiguration _config;
    public AuthRepository(IConfiguration config)
    {
      _config = config;
    }

    public Task<bool> IsUserExist(string username)
    {
      throw new System.NotImplementedException();
    }

    public Task<User> Login(string username, string password)
    {
      throw new System.NotImplementedException();
    }

    public Task<User> Register(User user, string password)
    {
      throw new System.NotImplementedException();
    }
  }
}