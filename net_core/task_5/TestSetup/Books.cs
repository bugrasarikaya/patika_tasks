using task_4.DBOperations;
using task_4.Entities;
namespace task_5.TestSetup {
	public static class Books {
		public static void AddBooks(this BookStoreDbContext context) {
			context.Books.AddRange(
				new Book { Title = "Lean Startup", AuthorID = 1, GenreID = 1, PageCount = 200, PublishDate = new DateTime(2001, 06, 12) },
				new Book { Title = "Herland", AuthorID = 2, GenreID = 2, PageCount = 250, PublishDate = new DateTime(2010, 05, 23) },
				new Book { Title = "Dune", AuthorID = 3, GenreID = 2, PageCount = 540, PublishDate = new DateTime(2001, 12, 21) }
			);
		}
	}
}
