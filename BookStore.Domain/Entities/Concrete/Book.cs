using BookStore.Domain.Entities.Enums;
using BookStore.Domain.Entities.Interface;
using System;
using System.Collections.Generic;

namespace BookStore.Domain.Entities.Concrete
{
    public class Book : IBase<int>, IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }

        public string GenreId { get; set; }
        public Genre Genre { get; set; }

        public List<BookAuthor> BookAuthors { get; set; }
    }
}
