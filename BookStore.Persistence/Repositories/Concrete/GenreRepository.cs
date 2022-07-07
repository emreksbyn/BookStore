using BookStore.Application.Repositories.EntityTypeRepositories;
using BookStore.Domain.Entities.Concrete;
using BookStore.Persistence.Context;
using BookStore.Persistence.Repositories.Abstract;

namespace BookStore.Persistence.Repositories.Concrete
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}