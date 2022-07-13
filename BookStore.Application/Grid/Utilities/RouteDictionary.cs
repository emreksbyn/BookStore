using BookStore.Application.Extensions;
using BookStore.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Application.Grid.Utilities
{
    public class RouteDictionary : Dictionary<string, string>
    {
        /*
            Ornek bir endpoint
            {controller}/{action}/page/{pagenumber}/size/{pagesize}/sort/{sortfield}/{sortdirection}/filter/{author}/{genre}/{price}

            Buradaki enpoint url de karsimiza cikacak yapidir. Buraki endpoint 4 tane bolumden (segment) olusmaktadir :
             1. /page/{pagenumber}
             2. /size/{pagesize}
             3. /sort/{sortfield}/{sortdirection}
             4. /filter/{author}/{genre}/{price}
         */
        /// <summary>
        ///  Bu fonksiyon disaridan aldigi key degerinin sozlukteki anahtar degerleri icerisinde var ise onu sinifin key ozelligi yoksa null donmektedir.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string Get(string key) => Keys.Contains(key) ? this[key] : null;

        public int PageNumber
        {
            // ToInt() metodunu kendimiz yazdik .
            get => Get(nameof(GridDTO.PageNumber)).ToInt();
            set => this[nameof(GridDTO.PageNumber)] = value.ToString();
        }

        public int PageSize
        {
            get => Get(nameof(GridDTO.PageSize)).ToInt();
            set => this[nameof(GridDTO.PageSize)] = value.ToString();
        }

        public string SortField
        {
            get => Get(nameof(GridDTO.SortField));
            set => this[nameof(GridDTO.SortField)] = value;
        }

        public string SortDirection
        {
            get => Get(nameof(GridDTO.SortDirection));
            set => this[nameof(GridDTO.SortDirection)] = value;
        }

        /// <summary>
        /// Sort yonunu set ettigimiz metodumuz
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="current"></param>
        public void SetSortAndDirection(string fieldName, RouteDictionary current)
        {
            this[nameof(GridDTO.SortDirection)] = fieldName;
            if (current.SortField.EqualNoCase(fieldName) && current.SortDirection == "asc")
            {
                this[nameof(GridDTO.SortDirection)] = "desc";
            }
            else
            {
                this[nameof(GridDTO.SortDirection)] = "asc";
            }
        }

        public RouteDictionary Clone()
        {
            var clone = new RouteDictionary();
            foreach (var key in Keys)
            {
                clone.Add(key, this[key]);
            }
            return clone;
        }

        public string GenreFilter
        {
            get => Get(nameof(BookGridDTO.Genre))?.Replace(FilterPrefix.Genre, " ");
            set => this[nameof(BookGridDTO.Genre)] = value;
        }

        public string PriceFilter
        {
            get => Get(nameof(BookGridDTO.Price))?.Replace(FilterPrefix.Price, "");
            set => this[nameof(BookGridDTO.Price)] = value;
        }

        public string AuthorFilter
        {
            // Yazar filtresi onek(prefix), yazar id ve slug icerir. (ornegin yazar-8-poper). Filtreleme icin yalnizca id' sine ihtiyacimiz bulunmaktadir. Bu nedenle once 'yazar-' onekini (prefix) string olan ifadeden kaldiriyoruz. Bu noktada, author un idsi string ifadenin basinda kalacaktir. Bu nedenle, id numarasinda numarasindan sonra tire index ini bulun ve ardindan index in baslangic degerini bu stringe substring olarak dondurun.
            get
            {
                string s = Get(nameof(BookGridDTO.Author))?.Replace(FilterPrefix.Author, " ");
                int index = s?.IndexOf('-') ?? -1;
                return (index == -1) ? s : s.Substring(0, index);
            }
            set => this[nameof(BookGridDTO.Author)] = value;
        }

        public void ClearFilters()
        {
            GenreFilter = PriceFilter = AuthorFilter = BookGridDTO.DefaultFilter;
        }
    }
}