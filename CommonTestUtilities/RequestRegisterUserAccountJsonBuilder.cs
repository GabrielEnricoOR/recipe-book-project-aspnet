using Bogus;
using MyRecipeBook.Communication;

namespace CommomTestUtilities;

public class RequestRegisterUserAccountJsonBuilder
{
    public static RequestRegisterUserAccountJson Builder()
    {
        return new Faker<RequestRegisterUserAccountJson>()
            .RuleFor(request => request.Name, f => f.Person.FirstName)
            .RuleFor(request => request.Email, (f, user) => f.Internet.Email(user.Name))
            .RuleFor(request => request.Password, f => f.Internet.Password());
    }
}