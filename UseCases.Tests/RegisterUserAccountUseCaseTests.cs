using CommomTestUtilities;
using CommomTestUtilities.Repositories;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Communication;
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

    private RegisterUserAccountUseCase CreateUseCase()
    {
        var unitOfWork = IUnitOfWorkBuilder.Build();
        var password = new IPasswordHashingBuilder().Build();
        var userWriteOnlyRepository = IUserWriteOnlyRepositoryBuilder.Build();
        var userReadOnlyRepository = new IUserReadOnlyRepositoryBuilder().Build();
        
        return new  RegisterUserAccountUseCase(password, userWriteOnlyRepository, unitOfWork ,userReadOnlyRepository);
    }
}