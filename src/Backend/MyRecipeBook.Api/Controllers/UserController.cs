using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Communication;

namespace MyRecipeBook.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    public IActionResult Register([FromBody] RequestRegisterUserAccountJson request)
    {
        return Created();
    }
}