using task_4.DBOperations;
using task_4.Entities;
namespace task_5.TestSetup {
	public static class Genres {
		public static void AddGenres(this BookStoreDbContext context) {
			context.Genres.AddRange(
				new Genre { Name = "Personal Growth" },
				new Genre { Name = "Science Fiction" },
				new Genre { Name = "Romance" }
			);
		}
	}
}