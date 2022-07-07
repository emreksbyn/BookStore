using BookStore.Application.Repositories.EntityTypeRepositories;
using BookStore.Application.UnitOfWork;
using BookStore.Persistence.Context;
using BookStore.Persistence.Repositories.Concrete;
using System;
using System.Threading.Tasks;

namespace BookStore.Persistence.UnitOfWorkConcrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext ?? throw new ArgumentNullException("db can't be null");
        }

        private IAuthorRepository _authorRepository;
        public IAuthorRepository AuthorRepository
        {
            get => _authorRepository ?? (_authorRepository = new AuthorRepository(_appDbContext));
        }

        private IBookRepository _bookRepository;
        public IBookRepository BookRepository
        {
            get => _bookRepository ?? (_bookRepository = new BookRepository(_appDbContext));
        }

        private IGenreRepository _genreRepository;
        public IGenreRepository GenreRepository
        {
            get => _genreRepository ?? (_genreRepository = new GenreRepository(_appDbContext));
        }

        private IUserRepository _userRepository;
        public IUserRepository UserRepository
        {
            get => _userRepository ?? (_userRepository = new UserRepository(_appDbContext));
        }

        public async Task Commit()
        {
            await _appDbContext.SaveChangesAsync();
        }

        private bool isDisposable = false;
        public async ValueTask DisposeAsync()
        {
            if (!isDisposable)
            {
                isDisposable = true;
                await DisposeAsync(true);
                GC.SuppressFinalize(this);
            }
        }

        protected async ValueTask DisposeAsync(bool disposing)
        {
            if (disposing)
            {
                await _appDbContext.DisposeAsync();
            }
        }
    }
}