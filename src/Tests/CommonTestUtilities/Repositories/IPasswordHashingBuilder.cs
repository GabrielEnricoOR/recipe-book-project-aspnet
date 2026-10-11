using Moq;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Domain.Security.PasswordHashing;

namespace CommomTestUtilities.Repositories;

public class IPasswordHashingBuilder
{
    private readonly Mock<IPasswordHashing> _mockPasswordHasher;

    public IPasswordHashingBuilder()
    {
        _mockPasswordHasher =  new Mock<IPasswordHashing>();
        
        _mockPasswordHasher.Setup(hasher => hasher.HashPassword(It.IsAny<string>())).Returns("hashed-password");
    }

    public IPasswordHashing Build()
    {
        return _mockPasswordHasher.Object;
    }

    public void VerifyPassword(string password)
    {
        _mockPasswordHasher.Setup(repository => repository.VerifyPassword(password, It.IsAny<string>())).Returns(true);
    }
}
