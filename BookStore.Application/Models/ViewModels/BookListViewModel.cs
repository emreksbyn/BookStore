using BookStore.Application.Grid.Utilities;
using BookStore.Domain.Entities.Concrete;
using System.Collections.Generic;

namespace BookStore.Application.Models.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPage { get; set; }
        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public Dictionary<string, string> Prices =>
            new Dictionary<string, string>
            {
                {"under7", "Under $7" },
                {"7to14", "$7 to $14" },
                {"over14", "Over 14" }
            };

        public int[] PageSize => new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    }
}