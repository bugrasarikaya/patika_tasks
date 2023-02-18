using movie_store.DBOperations;
using movie_store.Entities;
namespace xUnitTests.TestSetup {
	public static class MovieDirectors {
		public static void AddMovieDirectors(this MovieStoreDbContext context) {
			context.MovieDirectors.AddRange(
				new MovieDirector { ID = 1, MovieID = 1, DirectorID = 1 },
				new MovieDirector { ID = 2, MovieID = 2, DirectorID = 2 },
				new MovieDirector { ID = 3, MovieID = 3, DirectorID = 3 }
			);
		}
	}
}