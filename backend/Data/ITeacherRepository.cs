using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Data
{
  public interface ITeacherRepository
  {
    Teacher GetTeacherById(int id);

    List<Teacher> GetAllTeachers();
    
    Task<Teacher> CreateTeacher();
    
    Task<Teacher> UpdateTeacher();
    
    Task<Teacher> DeleteTeacher();
  }
}