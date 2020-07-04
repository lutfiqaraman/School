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

    public async Task<bool> IsUserExist(string username)
    {
      int id = 0;
      string connectionString = _config.GetConnectionString("SchoolDBConnection");
      string sqlQuery = "Select Id from user where UserName = @UserName";

      User user = new User();
      SqlConnection conn = new SqlConnection(connectionString);

      using (conn)
      {
        conn.Open();

        SqlCommand cmd = new SqlCommand(sqlQuery, conn);
        cmd.Parameters.AddWithValue("UserName", username);

        id = (int) await cmd.ExecuteScalarAsync();

        cmd.Dispose();
      }

      if (id != 0)
        return true;

      return false;
    }

    public async Task<User> Login(string username, string password)
    {
      int id = 0;
      string connectionString = _config.GetConnectionString("SchoolDBConnection");
      string sqlQuery = "Select Id from user where UserName = @UserName";

      User user = new User();
      SqlConnection conn = new SqlConnection(connectionString);

      using (conn)
      {
        conn.Open();

        SqlCommand cmd = new SqlCommand(sqlQuery, conn);
        cmd.Parameters.AddWithValue("UserName", username);

        id = (Int32)await cmd.ExecuteScalarAsync();

        cmd.Dispose();
      }

      if (id == 0)
        return null;

      bool result = VerifyingPassword(password, user.PasswordHash, user.PasswordSalt);

      if (!result)
        return null;

      return user;
    }

    private bool VerifyingPassword(string password, byte[] passwordHash, byte[] passwordSalt)
    {
      HMACSHA512 hmac = new HMACSHA512(passwordSalt);

      using (hmac)
      {
        byte[] computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        for (int i = 0; i < computedHash.Length; i++)
        {
          if (computedHash[i] != passwordHash[i])
            return false;
        }

        return true;
      }
    }

    public async Task<User> Register(User user, string password)
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
        await cmd.ExecuteNonQueryAsync();
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