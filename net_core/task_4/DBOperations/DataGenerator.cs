using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using task_4.Entities;
namespace task_4.DBOperations {
	public class DataGenerator {
		public static void Initialize(IServiceProvider serviceProvider) {
			using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>())) {
				if (context.Books.Any()) return;
				context.Genres.AddRange(
					new Genre {
						Name = "Personal Growth"
					},
					new Genre {
						Name = "Science Fiction"
					},
					new Genre {
						Name = "Romance"
					}
				);
				context.Books.AddRange(
				new Book {
					Title = "Lean Startup",
					GenreID = 1,
					PageCount = 200,
					PublishDate = new DateTime(2001, 06, 12)
				},
				new Book {
					Title = "Herland",
					GenreID = 2,
					PageCount = 250,
					PublishDate = new DateTime(2010, 05, 23)
				},
				new Book {
					Title = "Dune",
					GenreID = 2,
					PageCount = 540,
					PublishDate = new DateTime(2001, 12, 21)
				});
				context.SaveChanges();
			}
		}
	}
}