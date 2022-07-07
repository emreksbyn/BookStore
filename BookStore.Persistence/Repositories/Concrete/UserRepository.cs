using BookStore.Application.Repositories.EntityTypeRepositories;
using BookStore.Domain.Entities.Concrete;
using BookStore.Persistence.Context;
using BookStore.Persistence.Repositories.Abstract;

namespace BookStore.Persistence.Repositories.Concrete
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}