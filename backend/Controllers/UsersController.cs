using backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
  [Route("[controller]/[action]")]
  [ApiController]
  public class UsersController
  {
    private IUserRepository _repo;

    public UsersController(IUserRepository repo)
    {
      _repo = repo;
    }

  }
}