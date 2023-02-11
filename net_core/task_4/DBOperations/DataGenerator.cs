using Microsoft.EntityFrameworkCore;
using task_4.Entities;
namespace task_4.DBOperations {
	public class DataGenerator {
		public static void Initialize(IServiceProvider serviceProvider) {
			using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>())) {
				if (context.Books.Any()) return;
				context.Authors.AddRange(
					new Author {
						Name = "Eric",
						Surname = "Ries",
						DateofBirth = new DateTime(1978, 10, 22)
					},
					new Author {
						Name = "Charlotte Perkins",
						Surname = " Gilman",
						DateofBirth = new DateTime(2860, 7, 3)
					},
					new Author {
						Name = "Frank",
						Surname = "Herbert",
						DateofBirth = new DateTime(1920, 10, 8)
					}
				);
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
						AuthorID = 1,
						GenreID = 1,
						PageCount = 200,
						PublishDate = new DateTime(2001, 06, 12)
					},
					new Book {
						Title = "Herland",
						AuthorID = 2,
						GenreID = 2,
						PageCount = 250,
						PublishDate = new DateTime(2010, 05, 23)
					},
					new Book {
						Title = "Dune",
						AuthorID = 3,
						GenreID = 2,
						PageCount = 540,
						PublishDate = new DateTime(2001, 12, 21)
					}
				);
				context.SaveChanges();
			}
		}
	}
}