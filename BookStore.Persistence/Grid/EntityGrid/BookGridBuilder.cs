using BookStore.Application.Models.DTOs;
using BookStore.Domain.Entities.Concrete;
using BookStore.Persistence.Extensions;
using BookStore.Persistence.Grid.Base;
using BookStore.Persistence.Grid.Utilities;
using Microsoft.AspNetCore.Http;

namespace BookStore.Persistence.Grid.EntityGrid
{
    // Genel amaclar icin yazilmis GridBuilder sinifindan kalitim alan spesifik bir entity icin yazilmis bu sinif, route sozlugunde (dictionary) filtre rota segmentlerini yuklemek ve temizlemek icin uygulamaya ozel fonksiyonlar icermektedir. Ayrica siralama filtreleme icin uygulamaya ozel boolean bayraklar (flag) eklenmektedir.
    public class BookGridBuilder : GridBuilder
    {
        /// <summary>
        /// Bu Constructor sayfanin o anki var olan (current) route' i bize teslim eder ve calismak icin atasindan gelen ozellikleri gonderir.
        /// </summary>
        /// <param name="session"></param>
        public BookGridBuilder(ISession session) : base(session) { }

        /// <summary>
        /// Bu Ctor ise temel Ctor tarafindan Browser' in Storeage' ina yani Session depolanan sayfalama, siralama, filtreleme, route segmentlerini depolamaya yarayacaktir.
        /// Filtreleme route segmentlerini depolayacagiz. Ayrica bu route degerleri yerine varsayilan degerlere sahip ilk sayfa yuklemesinde filtre oneklerinide (prefix) ekliyoruz. (Route' taki filtrelerin prefix' lerinin oldugu unutulmamali.)
        /// </summary>
        /// <param name="session"></param>
        /// <param name="model"></param>
        /// <param name="defaultSortFilter"></param>
        public BookGridBuilder(ISession session, BookGridDTO model, string defaultSortFilter) : base(session, model, defaultSortFilter)
        {
            bool isInitial = model.Genre.IndexOf(FilterPrefix.Genre) == -1;
            Routes.AuthorFilter = (isInitial) ? FilterPrefix.Author + model.Author : model.Author;
            Routes.GenreFilter = (isInitial) ? FilterPrefix.Genre + model.Genre : model.Genre;
            Routes.PriceFilter = (isInitial) ? FilterPrefix.Price + model.Price : model.Price;
            SaveRouteSegment();
        }

        /// <summary>
        /// Bir string array' de bulunan yeni filtre route segmentlerini yukluyoruz. Her birine filtre onekleri (prefix) dahil edilmektedir. Yazara gore filtreleniyorsa (yalnizca tumu yerine) yazarin tam adi bilgisi eklenmektedir.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="author"></param>
        public void LoadFilterSegments(string[] filter, Author author)
        {
            if (author == null)
                Routes.AuthorFilter = FilterPrefix.Author + filter[0];
            else
                Routes.AuthorFilter = FilterPrefix.Author + filter[0] + "-" + (author.FullName).Slug();

            Routes.GenreFilter = FilterPrefix.Genre + filter[1];
            Routes.PriceFilter = FilterPrefix.Price + filter[2];
        }

        public void ClearFilterSegments() => Routes.ClearFilters();

        // Flags Mantigi => Sayet herhangi bir filtreleme yada sort istegi kullanicidan gelmisse yani varsa True yoksa False mantiginda calisacak ve bu bayraklarla her hangi bir filtrenin yada siralama isteginin olup olmadigini kontrol edecegimiz mekanizma

        // filter flags
        public bool IsFilterByAuthor => Routes.AuthorFilter != BookGridDTO.DefaultFilter;
        public bool IsFilterByGenre => Routes.GenreFilter != BookGridDTO.DefaultFilter;
        public bool IsFilterByPrice => Routes.PriceFilter != BookGridDTO.DefaultFilter;

        // sort flags
        public bool IsSortByGenre => Routes.SortField.EqualNoCase(nameof(Genre));
        public bool IsSortByPrice => Routes.SortField.EqualNoCase(nameof(Book.Price));
    }
}