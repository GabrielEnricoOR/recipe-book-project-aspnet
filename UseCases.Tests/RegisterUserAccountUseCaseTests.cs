using CommomTestUtilities;
using CommomTestUtilities.Repositories;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Communication;
using MyRecipeBook.Exception;
using MyRecipeBook.Exception.ExceptionBase;
using Shouldly;

namespace UseCases.Tests;

public class RegisterUserAccountUseCaseTests
{
    [Fact]
    public async Task Sucess()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();

        var useCase = CreateUseCase();
        
        var result = await useCase.Execute(request);
        result.ShouldNotBeNull();
        result.Name.ShouldBe(request.Name);
        result.Tokens.ShouldNotBeNull();
        result.Tokens.AcessToken.ShouldBeNullOrEmpty();
        result.Tokens.RefreshToken.ShouldBeNullOrEmpty();
    }

    [Fact]
    public async Task Validate_ShouldHaveError_WhenNameIsEmpty()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Name = string.Empty;
        
        var useCase = CreateUseCase();
        
        var exception = await useCase.Execute(request).ShouldThrowAsync<ErrorOnValidationException>();
        exception.GetErrorMessages().ShouldSatisfyAllConditions(error =>
        {
            error.Count.ShouldBe(1);
            error.ShouldContain(ResourceMessagesException.VALIDATION_NAME_REQUIRED);
        });
    } 
    
    public async Task Validate_ShouldHaveError_WhenEmailAlreadyExists()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        
        var useCase = CreateUseCase();
        
        var exception = await useCase.Execute(request).ShouldThrowAsync<ErrorOnValidationException>();
        exception.GetErrorMessages().ShouldSatisfyAllConditions(error =>
        {
            error.Count.ShouldBe(1);
            error.ShouldContain(ResourceMessagesException.VALIDATION_EMAIL_ALREADY_EXISTS);
        });
    }

    private RegisterUserAccountUseCase CreateUseCase(string? email = null)
    {
        var unitOfWork = IUnitOfWorkBuilder.Build();
        var password = new IPasswordHashingBuilder().Build();
        var userWriteOnlyRepository = IUserWriteOnlyRepositoryBuilder.Build();
        var userReadOnlyRepository = new IUserReadOnlyRepositoryBuilder();

        if (!string.IsNullOrWhiteSpace(email))
        {
            userReadOnlyRepository.ExistActiveUserWithEmail(email);
        }
        
        return new  RegisterUserAccountUseCase(password, userWriteOnlyRepository, unitOfWork ,userReadOnlyRepository.Build());
    }
}