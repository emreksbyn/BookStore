using BookStore.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.SeedData
{
    public class SeedBooks : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
              new Book { Id = 1, Title = "1776", GenreId = "history", Price = 18.00 },
              new Book { Id = 2, Title = "1984", GenreId = "scifi", Price = 5.50 },
              new Book { Id = 3, Title = "And Then There Were None", GenreId = "mystery", Price = 4.50 },
              new Book { Id = 4, Title = "Band of Brothers", GenreId = "history", Price = 11.50 },
              new Book { Id = 5, Title = "Beloved", GenreId = "novel", Price = 10.99 },
              new Book { Id = 6, Title = "Between the World and Me", GenreId = "memoir", Price = 13.50 },
              new Book { Id = 7, Title = "Bossypants", GenreId = "memoir", Price = 4.25 },
              new Book { Id = 8, Title = "Brave New World", GenreId = "scifi", Price = 16.25 },
              new Book { Id = 9, Title = "D-Day", GenreId = "history", Price = 15.00 },
              new Book { Id = 10, Title = "Down and Out in Paris and London", GenreId = "memoir", Price = 12.50 },
              new Book { Id = 11, Title = "Dune", GenreId = "scifi", Price = 8.75 },
              new Book { Id = 12, Title = "Emma", GenreId = "novel", Price = 9.00 },
              new Book { Id = 13, Title = "Frankenstein", GenreId = "scifi", Price = 6.50D },
              new Book { Id = 14, Title = "Go Tell it on the Mountain", GenreId = "novel", Price = 10.25 },
              new Book { Id = 15, Title = "Guns, Germs, and Steel", GenreId = "history", Price = 15.50 },
              new Book { Id = 16, Title = "Hunger", GenreId = "memoir", Price = 14.50 },
              new Book { Id = 17, Title = "Murder on the Orient Express", GenreId = "mystery", Price = 6.75 },
              new Book { Id = 18, Title = "Pride and Prejudice", GenreId = "novel", Price = 8.50 },
              new Book { Id = 19, Title = "Rebecca", GenreId = "mystery", Price = 10.99 },
              new Book { Id = 20, Title = "The Art of War", GenreId = "history", Price = 5.75 },
              new Book { Id = 21, Title = "The Girl with the Dragon Tattoo", GenreId = "mystery", Price = 8.50 },
              new Book { Id = 22, Title = "The Handmaid's Tale", GenreId = "scifi", Price = 12.50 },
              new Book { Id = 23, Title = "The Maltese Falcon", GenreId = "mystery", Price = 10.99 },
              new Book { Id = 24, Title = "The New Jim Crow", GenreId = "history", Price = 13.75 },
              new Book { Id = 25, Title = "The Year of Magical Thinking", GenreId = "memoir", Price = 13.50 },
              new Book { Id = 26, Title = "Wuthering Heights", GenreId = "novel", Price = 9.00 },
              new Book { Id = 27, Title = "Running With Scissors", GenreId = "memoir", Price = 11.00 },
              new Book { Id = 28, Title = "Pride and Prejudice and Zombies", GenreId = "novel", Price = 8.75 },
              new Book { Id = 29, Title = "Harry Potter and the Sorcerer's Stone", GenreId = "novel", Price = 9.75 });
        }
    }
}