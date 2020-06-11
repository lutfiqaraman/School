using System;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TeachersController : ControllerBase
  {
    [HttpGet]
    public IActionResult GetTeachers()
    {
      string test = "Get techars API";
      return Ok(test);
    }
  }
}