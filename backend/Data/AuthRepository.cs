using System.Threading.Tasks;
using backend.Models;

namespace backend.Data
{
  public class AuthRepository : IAuthRepository
  {
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