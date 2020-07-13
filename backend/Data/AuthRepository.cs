using System;
using System.Data;
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

      string connectionString = _config.GetConnectionString("SchoolDBConnection");
      string sqlQuery = "SELECT Id FROM Users " +
                        "where UserName = @UserName";

      User user = new User();
      SqlConnection conn = new SqlConnection(connectionString);

      using (conn)
      {
        conn.Open();

        SqlCommand cmd = new SqlCommand(sqlQuery, conn);
        cmd.Parameters.AddWithValue("UserName", username);

        object id = await cmd.ExecuteScalarAsync();

        if (id != null)
          return true;

        cmd.Dispose();
      }

      return false;
    }

    public async Task<User> Login(string username, string password)
    {
      
      string connectionString = _config.GetConnectionString("SchoolDBConnection");
      string sqlQuery = "SELECT Id, Username, PasswordHash, PasswordSalt " + 
                        "FROM Users WHERE UserName = @UserName";

      User user = new User();
      SqlConnection conn = new SqlConnection(connectionString);

      using (conn)
      {
        conn.Open();

        SqlCommand cmd = new SqlCommand(sqlQuery, conn);
        cmd.Parameters.AddWithValue("@UserName", username);

        object id = await cmd.ExecuteScalarAsync();

        if (id is null)
          return null;
        
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet dataSet = new DataSet();

        adapter.Fill(dataSet);

        user.Id = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Id"]);
        user.UserName = (string) dataSet.Tables[0].Rows[0]["Username"];
        user.PasswordHash = (Byte[]) dataSet.Tables[0].Rows[0]["PasswordHash"];
        user.PasswordSalt = (Byte[]) dataSet.Tables[0].Rows[0]["PasswordSalt"];

        cmd.Dispose();
      }

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
      string sqlQuery = "INSERT INTO Users (UserName, PasswordHash, PasswordSalt) " +  
                        "VALUES (@UserName, @PasswordHash, @PasswordSalt)";

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