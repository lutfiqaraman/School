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
  }
}