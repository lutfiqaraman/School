using System.Collections.Generic;
using backend.Models;
using Microsoft.Extensions.Configuration;

namespace backend.Data
{
  public class UserRepository : IUserRepository
  {

    private readonly IConfiguration _config;

    public UserRepository(IConfiguration config)
    {
      _config = config;
    }

    public List<User> GetAllUsers()
    {
      throw new System.NotImplementedException();
    }

    public User GetUserById(int id)
    {
      throw new System.NotImplementedException();
    }

    public User CreateUser()
    {
      throw new System.NotImplementedException();
    }

    public User UpdateUser()
    {
      throw new System.NotImplementedException();
    }

    public void DeleteUser(int id)
    {
      throw new System.NotImplementedException();
    }
  }
}