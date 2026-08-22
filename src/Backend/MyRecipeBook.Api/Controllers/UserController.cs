using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Communication;

namespace MyRecipeBook.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    [HttpPost("")]
    public IActionResult Register([FromBody] RequestRegisterUserAccountJson request)
    {
        var useCase = new RegisterUserAccountUseCase();
    
        useCase.Execute(request);

        return Created();
    }
}