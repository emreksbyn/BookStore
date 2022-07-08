using Newtonsoft.Json;

namespace BookStore.Application.Models.DTOs
{
    public class BookGridDTO : GridDTO
    {
        // Serialize islemlerinden bu property haric tutmak icin kullanilir.
        [JsonIgnore]
        public const string DefaultFilter = "all";
        public string Author { get; set; } = DefaultFilter;
        public string Genre { get; set; } = DefaultFilter;
        public string Price { get; set; } = DefaultFilter;
    }
}