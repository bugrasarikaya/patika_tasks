using movie_store.DBOperations;
using movie_store.Entities;
namespace xUnitTests.TestSetup {
	public static class Movies {
		public static void AddMovies(this MovieStoreDbContext context) {
			context.Movies.AddRange(
				new Movie { ID = 1, Name = "Ghostbusters", Year = 1984, Price = 19.99 },
				new Movie { ID = 2, Name = "The Dark Knight", Year = 2008, Price = 29.99 },
				new Movie { ID = 3, Name = "Romeo Is Bleeding", Year = 1993, Price = 6.99 }
			);
		}
	}
}