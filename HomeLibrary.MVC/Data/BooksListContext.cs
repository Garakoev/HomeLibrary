using Microsoft.EntityFrameworkCore;

namespace HomeLibrary.MVC.Models
{
    public class BooksListContext : DbContext
    {
        public BooksListContext(DbContextOptions<BooksListContext> options)
            : base(options)
        {
        }

        public DbSet<BooksList> BooksList { get; set; } = default!;
    }
}