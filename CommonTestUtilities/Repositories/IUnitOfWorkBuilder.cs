using Moq;
using MyRecipeBook.Domain.Repositories;

namespace CommomTestUtilities.Repositories;

public class IUnitOfWorkBuilder
{
    public static IUnitOfWork Build()
    {
        var mock = new Mock<IUnitOfWork>();
        
        return mock.Object;
    }
}