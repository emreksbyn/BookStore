using BookStore.Domain.Entities.Enums;
using BookStore.Domain.Entities.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Domain.Entities.Concrete
{
    public class Author : IBase<int>, IBaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName => FirstName + " " + LastName;

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }

        // Bir kitabın birden cok yazari olabilir ve bir yazar birden fazla kitap yazmis olabilir. Bu yuzden kitap ve yazar arasında Coka cok ( N - N ) iliski kuracagiz.
        public List<BookAuthor> BookAuthors { get; set; }
    }
}
