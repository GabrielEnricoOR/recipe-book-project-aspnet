using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Communication;
using MyRecipeBook.Exception;

namespace MyRecipeBook.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    [HttpPost("/register")]
    public IActionResult Register(
        [FromBody] RequestRegisterUserAccountJson request, 
        [FromServices] IRegisterUserAccountUseCase useCase
        )
    {
        useCase.Execute(request);

        return Created();
    }
}