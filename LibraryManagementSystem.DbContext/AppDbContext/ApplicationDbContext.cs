using LibraryManagementSystem.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.DbContext.AppDbContext
{
    public class ApplicationDbContext:Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=RAKTIM-PC;Database=LibraryManagement;Trusted_Connection=true");
        }

        public virtual DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
    }
}
