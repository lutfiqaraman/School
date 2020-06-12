using System.Threading.Tasks;
using backend.Models;
using Microsoft.Extensions.Configuration;

namespace backend.Data
{
  public class TeacherRepository : ITeacherRepository
  {
    private readonly IConfiguration _config;

    // To get all teachers from database
    public Task<Teacher> GetAllTeachers()
    {
      throw new System.NotImplementedException();
    }

    public TeacherRepository(IConfiguration config)
    {
      _config = config;
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