using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
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

    public User Register(User user, string password)
    {
      byte[] passwordHash, passwordSalt;
      CreateHashedPassword(password, out passwordHash, out passwordSalt);

      user.PasswordHash = passwordHash;
      user.PasswordSalt = passwordSalt;

      string connectionString = _config.GetConnectionString("SchoolDBConnection");
      string sqlQuery = "INSERT INTO User (UserName, PasswordHash, PasswordSalt) VALUES (@UserName, @PasswordHash, @PasswordSalt)";

      SqlConnection conn = new SqlConnection(connectionString);

      using (conn)
      {
        SqlCommand cmd = new SqlCommand(sqlQuery, conn);

        cmd.Parameters.AddWithValue("@UserName", user.UserName);
        cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
        cmd.Parameters.AddWithValue("@PasswordSalt", user.PasswordSalt);

        conn.Open();
        cmd.ExecuteNonQuery();
      }

      return user;
    }

    private void CreateHashedPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
      var hmac = new HMACSHA512();

      using (hmac)
      {
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
      }
    }
  }
}