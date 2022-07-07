using BookStore.Domain.Entities.Enums;
using BookStore.Domain.Entities.Interface;
using Microsoft.AspNetCore.Identity;
using System;

namespace BookStore.Domain.Entities.Concrete
{
    // IdentityUser icin Microsoft.AspNetCore.Identity.EntityFrameworkCore paketi indirildi.
    public class User : IdentityUser, IBaseEntity
    {
        // Tohumlama yaparken CreateDate ve Status bilgileri otomatik olarak olusturulsun diye encapsulation yaptik.
        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }
    }
}