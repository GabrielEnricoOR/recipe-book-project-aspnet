using System;
using Mapster;
using MyRecipeBook.Communication;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Domain.Security.PasswordHashing;
using MyRecipeBook.Exception.ExceptionBase;

namespace MyRecipeBook.Application.UseCases.User.Register;

public class RegisterUserAccountUseCase : IRegisterUserAccountUseCase
{
    private readonly IPasswordHashing _passwordHashing;  
    private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;

    public RegisterUserAccountUseCase(IPasswordHashing password, IUserWriteOnlyRepository userWriteOnlyRepository)
    {
        _passwordHashing = password;
        _userWriteOnlyRepository = userWriteOnlyRepository;
    }


    public async Task Execute(RequestRegisterUserAccountJson request)
    {
        ValidateAndThrowOnError(request);

        var user = request.Adapt<Domain.Entities.User>();

        user.Password = _passwordHashing.HashPassword(request.Password);
        await _userWriteOnlyRepository.Add(user);

    }

    private void ValidateAndThrowOnError(RequestRegisterUserAccountJson request)
    {
        var validator = new RegisterUserAccountValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            List<string> errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
