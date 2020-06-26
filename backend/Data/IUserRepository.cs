using System.Collections.Generic;
using backend.Models;

namespace backend.Data
{
  public interface IUserRepository
  {
    User GetUserById(int id);
    List<User> GetAllUsers();
    User CreateUser();
    User UpdateUser();
    void DeleteUser(int id);
  }
}