using backend.Data;
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
  }
}