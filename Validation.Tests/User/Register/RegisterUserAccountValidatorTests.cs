using CommomTestUtilities;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Communication;
using Shouldly;

namespace Validation.Tests.User.Register;


public class RegisterUserAccountValidatorTests
{

    [Fact]
    public void Sucess()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Builder();

        var validator = new RegisterUserAccountValidator();

        var result = validator.Validate(request);
        
        result.IsValid.ShouldBeTrue();
    }
}