using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Communication;

namespace Validation.Tests.User.Register;


public class RegisterUserAccountValidatorTests
{

    [Fact]
    public void Sucess()
    {
        var request = new RequestRegisterUserAccountJson()
        {
            Name =  "John",
            Password = "123456",
            Email = "John@gmail.com"
            
        };

        var validator = new RegisterUserAccountValidator();

        var result = validator.Validate(request);
        
        Assert.True(result.IsValid);
    }
}