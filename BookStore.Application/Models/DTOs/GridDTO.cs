namespace BookStore.Application.Models.DTOs
{
    public class GridDTO
    {
        // Kullanici bir sayfa goruntulemek istediginde default olarak Grid bu ozellikler ile olusturulacak.
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 4;
        public string SortField { get; set; }
        public string SortDirection { get; set; } = "asc";
    }
}