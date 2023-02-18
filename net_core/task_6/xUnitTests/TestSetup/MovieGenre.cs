using movie_store.DBOperations;
using movie_store.Entities;
namespace xUnitTests.TestSetup {
	public static class MovieGenres {
		public static void AddMovieGenres(this MovieStoreDbContext context) {
			context.MovieGenres.AddRange(
				new MovieGenre { ID = 1, MovieID = 1, GenreID = 1 },
				new MovieGenre { ID = 2, MovieID = 2, GenreID = 1 },
				new MovieGenre { ID = 3, MovieID = 2, GenreID = 2 },
				new MovieGenre { ID = 4, MovieID = 3, GenreID = 2 },
				new MovieGenre { ID = 5, MovieID = 3, GenreID = 3 }
			);
		}
	}
}