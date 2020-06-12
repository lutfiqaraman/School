using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.Extensions.Configuration;

namespace backend.Data
{
  public class TeacherRepository : ITeacherRepository
  {
    private readonly IConfiguration _config;

    // Teacher Repository - Constructor
    public TeacherRepository(IConfiguration config)
    {
      _config = config;
    }

    // To get all teachers from database
    public Task<List<Teacher>> GetAllTeachers()
    {
      string connectionString = _config.GetConnectionString("SchoolDBConnection");
      throw new System.NotImplementedException();
    }

    public Task<Teacher> CreateTeacher()
    {
      throw new System.NotImplementedException();
    }

    public Task<Teacher> DeleteTeacher()
    {
      throw new System.NotImplementedException();
    }

    public Task<Teacher> GetTeacher()
    {
      throw new System.NotImplementedException();
    }

    public Task<Teacher> UpdateTeacher()
    {
      throw new System.NotImplementedException();
    }
  }
}