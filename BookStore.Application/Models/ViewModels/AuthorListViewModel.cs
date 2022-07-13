using BookStore.Domain.Entities.Concrete;
using BookStore.Application.Grid.Utilities;
using System.Collections.Generic;

namespace BookStore.Application.Models.ViewModels
{
    public class AuthorListViewModel
    {
        public IEnumerable<Author> Authors { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }
    }
}