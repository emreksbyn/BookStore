using BookStore.Application.Extensions;
using BookStore.Application.Grid.Base;
using BookStore.Application.Models.DTOs;
using BookStore.Application.Models.ViewModels;
using BookStore.Application.Repositories.Queries;
using BookStore.Application.UnitOfWork;
using BookStore.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public async Task<ViewResult> List(GridDTO model)
        {
            string defaultSort = nameof(Author.LastName);
            var builder = new GridBuilder(HttpContext.Session, model, defaultSort);
            builder.SaveRouteSegment();

            var options = new QueryOptions<Author>
            {
                Includes = "BookAuthors.Book",
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize,
                OrderByDirection = builder.CurrentRoute.SortDirection
            };

            if (builder.CurrentRoute.SortField.EqualNoCase(defaultSort))
            {
                options.OrderBy = a => a.LastName;
            }
            else
            {
                options.OrderBy = a => a.FirstName;
            }

            var viewModel = new AuthorListViewModel
            {
                Authors = await _unitOfWork.AuthorRepository.List(options),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(_unitOfWork.AuthorRepository.Count)
            };

            return View(viewModel);
        }

        public async Task<ViewResult> Details(int id)
        {
            var author = await _unitOfWork.AuthorRepository.Get(new QueryOptions<Author>
            {
                Includes = "BookAuthor.Book",
                Where = a => a.Id == id
            });
            return View(author);
        }
    }
}