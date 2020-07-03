using System.Threading.Tasks;
using backend.Models;

namespace backend.Data
{
  public interface IAuthRepository
  {
    User Register(User user, string password);
    User Login(string username, string password);
    Task<bool> IsUserExist(string username);
  }
}