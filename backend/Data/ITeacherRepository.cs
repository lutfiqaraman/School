using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Data
{
  public interface ITeacherRepository
  {
    Task<Teacher> GetTeacherById(int id);

    List<Teacher> GetAllTeachers();
    
    Teacher CreateTeacher(Teacher teacher);
    
    Teacher UpdateTeacher(Teacher teacher, int id);
    
    void DeleteTeacher(int id);
  }
}