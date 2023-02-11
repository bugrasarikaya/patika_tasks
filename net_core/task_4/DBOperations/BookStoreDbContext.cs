using Microsoft.EntityFrameworkCore;
using task_4.Entities;
namespace task_4.DBOperations {
	public class BookStoreDbContext : DbContext {
		public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Genre> Genres { get; set; }
	}
}