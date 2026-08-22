using System;
using System.Data;
using FluentValidation;
using MyRecipeBook.Communication;
using MyRecipeBook.Exception;

namespace MyRecipeBook.Application.UseCases.User.Register;

public class RegisterUserAccountValidator : AbstractValidator<RequestRegisterUserAccountJson>
{
    public RegisterUserAccountValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMessagesException.VALIDATION_USER_NAME);
        RuleFor(user => user.Email).NotEmpty().WithMessage("Email is required");
        RuleFor(user => user.Password).NotEmpty().WithMessage("Password is required");
        When(user => string.IsNullOrEmpty(user.Email) == false, () =>
        {
           RuleFor(user => user.Email).EmailAddress().WithMessage("Email is not valid");
        });
    }
}
