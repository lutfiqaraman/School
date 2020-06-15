using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Data
{
  public interface ITeacherRepository
  {
    Teacher GetTeacherById(int id);

    List<Teacher> GetAllTeachers();
    
    void CreateTeacher(Teacher teacher);
    
    Teacher UpdateTeacher(int id);
    
    void DeleteTeacher(int id);
  }
}