using BookStore.Application.Repositories.EntityTypeRepositories;
using BookStore.Domain.Entities.Concrete;
using BookStore.Persistence.Context;
using BookStore.Persistence.Repositories.Abstract;

namespace BookStore.Persistence.Repositories.Concrete
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}