using Moq;
using MyRecipeBook.Domain.Repositories.User;

namespace CommomTestUtilities.Repositories;

public class IUserWriteOnlyRepositoryBuilder
{
    public static IUserWriteOnlyRepository Build()
    {
        var mock = new Mock<IUserWriteOnlyRepository>();
        
        return mock.Object; 
    }
}