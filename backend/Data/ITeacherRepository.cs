using System.Collections.Generic;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

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