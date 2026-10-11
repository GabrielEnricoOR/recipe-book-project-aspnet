using CommomTestUtilities;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Communication;
using MyRecipeBook.Exception;
using Shouldly;

namespace Validation.Tests.User.Register;


public class RegisterUserAccountValidatorTests
{

    [Fact]
    public void Sucess()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();

        var validator = new RegisterUserAccountValidator();

        var result = validator.Validate(request);
        
        result.IsValid.ShouldBeTrue();
    }

    [Fact]
    public void Validate_ShouldHaveError_WhenNameIsEmpty()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Name = string.Empty;

        var validator = new RegisterUserAccountValidator();

        var result = validator.Validate(request);
        
        result.IsValid.ShouldBeFalse();
        
        result.Errors.ShouldSatisfyAllConditions(error =>
        {
            error.Count.ShouldBe(1);
            error.ShouldContain(error => error.ErrorMessage.Equals(ResourceMessagesException.VALIDATION_NAME_REQUIRED));
        });
    }
    
    [Fact]
    public void Validate_ShouldHaveError_WhenEmailIsEmpty()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Email = string.Empty;

        var validator = new RegisterUserAccountValidator();

        var result = validator.Validate(request);
        
        result.IsValid.ShouldBeFalse();
        
        result.Errors.ShouldSatisfyAllConditions(error =>
        {
            error.Count.ShouldBe(1);
            error.ShouldContain(error => error.ErrorMessage.Equals(ResourceMessagesException.VALIDATION_EMAIL_REQUIRED));
        });
    }
    
    [Fact]
    public void Validate_ShouldHaveError_WhenPasswordIsEmpty()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Password = string.Empty;

        var validator = new RegisterUserAccountValidator();

        var result = validator.Validate(request);
        
        result.IsValid.ShouldBeFalse();
        
        result.Errors.ShouldSatisfyAllConditions(error =>
        {
            error.Count.ShouldBe(1);
            error.ShouldContain(error => error.ErrorMessage.Equals(ResourceMessagesException.VALIDATION_PASSWORD_REQUIRED));
        });
    }
    
    [Fact]
    public void Validate_ShouldHaveError_WhenEmailIsNotValid()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Email = "recipe123";

        var validator = new RegisterUserAccountValidator();

        var result = validator.Validate(request);
        
        result.IsValid.ShouldBeFalse();
        
        result.Errors.ShouldSatisfyAllConditions(error =>
        {
            error.Count.ShouldBe(1);
            error.ShouldContain(error => error.ErrorMessage.Equals(ResourceMessagesException.VALIDATION_EMAIL_INVALID));
        });
    }
}