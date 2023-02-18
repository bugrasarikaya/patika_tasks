using movie_store.DBOperations;
using movie_store.Entities;
namespace xUnitTests.TestSetup {
	public static class MovieActors {
		public static void AddMovieActors(this MovieStoreDbContext context) {
			context.MovieActors.AddRange(
				new MovieActor { ID = 1, MovieID = 1, ActorID = 1 },
				new MovieActor { ID = 2, MovieID = 2, ActorID = 2 },
				new MovieActor { ID = 3, MovieID = 2, ActorID = 3 },
				new MovieActor { ID = 4, MovieID = 3, ActorID = 3 }
			);
		}
	}
}