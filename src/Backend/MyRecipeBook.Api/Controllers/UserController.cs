using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Communication;
using MyRecipeBook.Communication.Responses;
using MyRecipeBook.Exception;

namespace MyRecipeBook.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    [HttpPost("/register")]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson),StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson),StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromBody] RequestRegisterUserAccountJson request, 
        [FromServices] IRegisterUserAccountUseCase useCase
        )
    {
        var result = await useCase.Execute(request);

        return Created(string.Empty, result);
    }
}