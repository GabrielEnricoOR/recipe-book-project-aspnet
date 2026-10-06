using CommomTestUtilities;
using CommomTestUtilities.Repositories;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Communication;

namespace UseCases.Tests;

public class RegisterUserAccountUseCaseTests
{
    [Fact]
    public async Task Sucess()
    {
        var request = RequestRegisterUserAccountJsonBuilder.Build();

        var useCase = CreateUseCase();
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