using BookStore.Application.Repositories.BaseRepository;
using BookStore.Domain.Entities.Concrete;

namespace BookStore.Application.Repositories.EntityTypeRepositories
{
    public interface IBookRepository : IBaseRepository<Book> { }
}