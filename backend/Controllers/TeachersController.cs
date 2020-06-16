using System.Collections.Generic;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class TeachersController
  {
    private readonly ITeacherRepository _repo;
    
    public TeachersController(ITeacherRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public List<Teacher> GetTeachers()
    {
      return _repo.GetAllTeachers();
    }

    [HttpGet("{id}")]
    public Teacher GetTeacher(int id)
    {
      return _repo.GetTeacherById(id);
    }

    [HttpPost]
    public Teacher PostTeacher([FromBody] Teacher teacher)
    {
      return _repo.CreateTeacher(teacher);
    }

    [HttpPut("{id}")]
    public Teacher UpdateTeacher([FromBody] Teacher teacher, int id)
    {
      return _repo.UpdateTeacher(teacher, id);
    }

    [HttpDelete("{id}")]
    public void DeleteTeacher(int id)
    {
      _repo.DeleteTeacher(id);
    }
  }
}