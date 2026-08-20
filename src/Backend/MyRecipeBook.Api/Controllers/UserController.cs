using Microsoft.AspNetCore.Mvc;

namespace MyRecipeBook.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    public IActionResult Register()
    {
        return Created();
    }
}