using BookDictionary.Models;
using Microsoft.EntityFrameworkCore;

namespace BookDictionary.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Genre>()
                .HasOne(b => b.Book)
                .WithMany(bg => bg.Book_Genres)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<Book_Genre>()
                .HasOne(b => b.Genre)
                .WithMany(bg => bg.Book_Genres)
                .HasForeignKey(bi => bi.GenreId);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Auther> Authers { get; set; }
        public DbSet<Book_Genre> Book_Genres { get; set; }
        public DbSet<BookDictionary.Models.Country> Country { get; set; } = default!;

    }
}
