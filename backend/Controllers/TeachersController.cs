using backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class TeachersController
  {
    private readonly ITeacherRepository _repository;
    public TeachersController(ITeacherRepository repository)
    {
      _repository = repository;
    }
  }
}