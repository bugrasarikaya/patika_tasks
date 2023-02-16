using movie_store.DBOperations;
using movie_store.Entities;
namespace xUnitTests.TestSetup {
	public static class Genres {
		public static void AddGenres(this MovieStoreDbContext context) {
			context.Genres.AddRange(
				new Genre { ID = 1, Name = "Action" },
				new Genre { ID = 2, Name = "Crime" },
				new Genre { ID = 3, Name = "Romance" }
			);
		}
	}
}