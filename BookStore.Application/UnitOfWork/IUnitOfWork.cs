using BookStore.Application.Repositories.EntityTypeRepositories;
using System;
using System.Threading.Tasks;

namespace BookStore.Application.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IAuthorRepository AuthorRepository { get; }
        IBookRepository BookRepository { get; }
        IGenreRepository GenreRepository { get; }
        IUserRepository UserRepository { get; }
        Task Commit();
    }
}