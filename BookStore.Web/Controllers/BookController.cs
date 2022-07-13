using BookStore.Application.Extensions;
using BookStore.Application.Grid.EntityGrid;
using BookStore.Application.Models.DTOs;
using BookStore.Application.Models.ViewModels;
using BookStore.Application.Repositories.Queries;
using BookStore.Application.UnitOfWork;
using BookStore.Domain.Entities.Concrete;
using BookStore.Persistence.EntityQueries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public async Task<ViewResult> List(BookGridDTO model)
        {
            // Session dan current route segmentlerini alalim
            var builder = new BookGridBuilder(HttpContext.Session, model, defaultSortFilter: nameof(Book.Title));

            var options = new BookQueryOptions
            {
                Includes = "BookAuthors.Author, Genre",
                OrderByDirection = builder.CurrentRoute.SortDirection,
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize
            };

            options.SortFilter(builder);

            var viewModel = new BookListViewModel
            {
                Books = await _unitOfWork.BookRepository.List(options),
                Authors = await _unitOfWork.AuthorRepository.List(new QueryOptions<Author> { OrderBy = a => a.FirstName }),
                Genres = await _unitOfWork.GenreRepository.List(new QueryOptions<Genre> { OrderBy = g => g.Name }),
                CurrentRoute = builder.CurrentRoute,
                TotalPage = builder.GetTotalPages(_unitOfWork.BookRepository.Count)
            };

            return View(viewModel);
        }

        public async Task<ViewResult> Details(int id)
        {
            //var book = await _unitOfWork.BookRepository.Get(new QueryOptions<Book>
            //{
            //    Includes = "BookAuthors.Author, Genre",
            //    Where = b => b.Id == id
            //});
            //return View(book);
            var book = await _unitOfWork.BookRepository.Get(new QueryOptions<Book>
            {
                Includes = "BookAuthors.Author, Genre",
                Where = b => b.Id == id
            });

            return View(book);
        }

        [HttpPost]
        public async Task<RedirectToActionResult> Filter(string[] filter, bool clear = false)
        {
            // get current route segments from session
            var builder = new BookGridBuilder(HttpContext.Session);

            // filter route segmentleri clear or update
            if (clear)
            {
                builder.ClearFilterSegments();
            }
            else
            {
                // Eger bir update durumu soz konusu ise author data sini db den getirmek gerekmektedir. Bunu yapmamizdaki amac author name ve bu baglamda olusturulacak slug author filtresine dahil edilsin
                var author = await _unitOfWork.AuthorRepository.Get(filter[0].ToInt());
                builder.CurrentRoute.PageNumber = 1;
                builder.LoadFilterSegments(filter, author);
            }

            // SaveRouteSegment() metodu ile olusturulan route datasini session' da depolamak icin kullandik ve "Book/List" actions Redirect olduk. Bu actiona giderken build olmus Url ve route segment value dictioanary si ile gittik.
            builder.SaveRouteSegment();
            return RedirectToAction("List", builder.CurrentRoute);
        }

        [HttpPost]
        public RedirectToActionResult PageSize(int pageSize)
        {
            var builder = new BookGridBuilder(HttpContext.Session);
            builder.CurrentRoute.PageSize = pageSize;
            builder.SaveRouteSegment();
            return RedirectToAction("List", builder.CurrentRoute);
        }
    }
}