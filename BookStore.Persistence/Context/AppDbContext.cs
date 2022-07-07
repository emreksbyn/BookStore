using BookStore.Domain.Entities.Concrete;
using BookStore.Persistence.SeedData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace BookStore.Persistence.Context
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new SeedAuthors());
            builder.ApplyConfiguration(new SeedBookAuthors());
            builder.ApplyConfiguration(new SeedBooks());
            builder.ApplyConfiguration(new SeedGenres());
        }

        public static async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string username = "admin", password = "Password", roleName = "Admin";

            // Role yoksa olustur.
            if (await roleManager.FindByNameAsync(roleName)==null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            // username yoksa olustur ve rolu ata.
            if (await userManager.FindByNameAsync(username)==null)
            {
                User user = new User { UserName = username };
                var result = await userManager.CreateAsync(user, password);
                if (result == IdentityResult.Success)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
    }
}