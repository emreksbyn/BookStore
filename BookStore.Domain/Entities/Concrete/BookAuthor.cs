using BookStore.Domain.Entities.Enums;
using BookStore.Domain.Entities.Interface;
using System;

namespace BookStore.Domain.Entities.Concrete
{
    public class BookAuthor : IBase<int>, IBaseEntity
    {
        public int Id { get; set; }
        //Dummy Table olarak veri tabaninda olusturulacak bu sinif sadece Foreign Key icerecektir.
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }
    }
}