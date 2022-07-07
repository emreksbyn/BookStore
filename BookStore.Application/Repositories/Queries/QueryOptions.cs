using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BookStore.Application.Repositories.Queries
{
    public class QueryOptions<T>
    {
        /* QueryOptions kullanımı
        var options = new QueryOptions<Book>
        {
            Include = "BookAuthors, Genres",
            WhereClauses = new WhereClauses<Book> 
            {
                { x=> x.GenreId == "history" },
                { x=> x.Pride < 10 },
                { x => x.Status != Status.Passive }
            }
        }   
         */
        public Expression<Func<T, Object>> OrderBy { get; set; }
        /// <summary>
        /// Dinamik olarak kullanici isterse "asc" isterse "desc" gonderebilir. Herhangi bir Order by yonu belirtmezse "asc" default olarak kabul edilir.
        /// </summary>
        public string OrderByDirection { get; set; } = "asc";
        /// <summary>
        /// Kullanici tarafindan sayfalama icin gelecek parametrelerden biridir. Kullanici isterse 1 sayfada 10 urun gormek isteyebilir. Totalde 100 urun varsa bunu 10 sayfaya dagıtmak gerekir.
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// Kullanici tarafindan sayfalama icin gelecek parametrelerden biridir. Kullanici isterse 1 sayfada 10 urun gormek isteyebilir. Totalde 100 urun varsa bunu 10 sayfaya dagıtmak gerekir.
        /// </summary>
        public int PageSize { get; set; }
        // Yukarida yorumda query options' in include alani incelendiginde " Include = "BookAuthors, Genres", burada bir string manuplasyonu yapmamiz gerektigini gorebilirsiniz. Burada Replace() metodu ile bosluklari kaldirip ve virgul karakterlerinden split etmemiz gerekmektedir.
        // Bu islem icin ilk once burada yasayacak bir buffer array acacagiz.
        // Split methodu bize string[] donmekteydi. Split ettikten sonra buradaki disariya kapali array icerisine dolduracagiz.
        private string[] includes;
        public string Includes
        {
            set => includes = value.Replace(" ", "").Split(",");
        }
        // Asagidaki methodu query e dahil edilen yani include edilen tablo bilgisini get etmek icin kullanacagiz. Sayet "includes" dizisi dolu ise onu bize donecek degilse bos bir array' in 0. indeksini yani null donecek.
        public string[] GetInclude()
        {
            return includes ?? new string[0];
        }
        public WhereClauses<T> WhereClauses { get; set; }
        public Expression<Func<T, bool>> Where
        {
            set
            {
                if (WhereClauses == null)
                {
                    WhereClauses = new WhereClauses<T>();
                }
                WhereClauses.Add(value);
            }
        }
        public bool HasWhere => WhereClauses != null;
        public bool HasOrderBy => OrderBy != null;
        public bool HasPaging => PageNumber > 0 && PageSize > 0;
    } 
    // Query Options icerisinde where cumleleri yazarken bu sinifi new leyerek icerisini dolduracagiz. Yukaridaki yorumda olan ornekte oldugu gibi.
    public class WhereClauses<T> : List<Expression<Func<T, bool>>> { }
}