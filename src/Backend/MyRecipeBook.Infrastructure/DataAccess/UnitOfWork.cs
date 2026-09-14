using MyRecipeBook.Domain.Repositories;
using MyRecipeBook.Domain.Repositories.User;

namespace MyRecipeBook.Infrastructure.DataAccess;

internal class UnitOfWork : IUnitOfWork
{
    private readonly IUserWriteOnlyRepository _repository;
    private readonly MyRecipeBookDbContext _context;

    public UnitOfWork(IUserWriteOnlyRepository repository, MyRecipeBookDbContext context)
    {
        _repository = repository;
        _context = context;
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }
}