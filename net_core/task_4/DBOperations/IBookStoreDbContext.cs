using Microsoft.EntityFrameworkCore;
using task_4.Entities;
namespace task_4.DBOperations {
	public interface IBookStoreDbContext {
		DbSet<Author> Authors { get; set; }
		DbSet<Book> Books { get; set; }
		DbSet<Genre> Genres { get; set; }
		int SaveChanges();
	}
}