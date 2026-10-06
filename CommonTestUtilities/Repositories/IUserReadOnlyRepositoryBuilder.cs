using Moq;
using MyRecipeBook.Domain.Repositories.User;

namespace CommomTestUtilities.Repositories;

public class IUserReadOnlyRepositoryBuilder
{
    private readonly Mock<IUserReadOnlyRepository> _mockReadOnlyRepository;
    
    public IUserReadOnlyRepositoryBuilder()
    {
            _mockReadOnlyRepository =  new Mock<IUserReadOnlyRepository>();
    }

    public IUserReadOnlyRepository Build()
    {
        return _mockReadOnlyRepository.Object;
    }

    public void ExistActiveUserWithEmail(string email)
    {
        _mockReadOnlyRepository.Setup(repository => repository.ExistActiveUserWithEmail(email)).ReturnsAsync(true);
    }
}