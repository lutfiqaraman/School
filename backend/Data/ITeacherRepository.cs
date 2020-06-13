using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Data
{
  public interface ITeacherRepository
  {
    Teacher GetTeacherById(int id);

    List<Teacher> GetAllTeachers();
    
    Teacher CreateTeacher();
    
    Teacher UpdateTeacher(int id);
    
    Teacher DeleteTeacher(int id);
  }
}