using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace task_3.DBOperations {
	public class DataGenerator {
		public static void Initialize(IServiceProvider serviceProvider) {
			using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>())) {
				if (context.Books.Any()) return;
				context.Books.AddRange(
				new Book {
					Title = "Lean Startup",
					GenreID = 1, // Personal Growth
					PageCount = 200,
					PublishDate = new DateTime(2001, 06, 12)
				},
				new Book {
					Title = "Herland",
					GenreID = 2, // Science Fiction
					PageCount = 250,
					PublishDate = new DateTime(2010, 05, 23)
				},
				new Book {
					Title = "Dune",
					GenreID = 2,  // Science Fiction
					PageCount = 540,
					PublishDate = new DateTime(2001, 12, 21)
				});
				context.SaveChanges();
			}
		}
	}
}