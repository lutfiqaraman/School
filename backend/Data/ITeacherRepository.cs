using System.Collections.Generic;
using backend.Models;

namespace backend.Data
{
  public interface ITeacherRepository
  {
    Teacher GetTeacherById(int id);

    List<Teacher> GetAllTeachers();
    
    Teacher CreateTeacher(Teacher teacher);
    
    Teacher UpdateTeacher(Teacher teacher, int id);
    
    void DeleteTeacher(int id);
  }
}