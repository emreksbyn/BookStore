using BookStore.Domain.Entities.Enums;
using BookStore.Domain.Entities.Interface;
using System;
using System.Collections.Generic;

namespace BookStore.Domain.Entities.Concrete
{
    public class Genre : IBase<string>, IBaseEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }

        public List<Book> Books { get; set; }
    }
}