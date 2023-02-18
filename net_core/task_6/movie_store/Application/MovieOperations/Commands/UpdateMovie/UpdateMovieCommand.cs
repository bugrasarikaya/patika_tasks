using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.MovieOperations.Commands.UpdateMovie {
	public class UpdateMovieCommand {
		public int MovieID { get; set; }
		public UpdateMovieModel Model { get; set; } = null!;
		private readonly IMovieStoreDbContext context;
		public UpdateMovieCommand(IMovieStoreDbContext context) {
			this.context = context;
		}
		public void Handle() {
			Movie? movie = context.Movies.SingleOrDefault(m => m.ID == MovieID);
			if (movie == null) throw new InvalidOperationException("Movie could not be found.");
			movie.Name = Model.Name != default ? Model.Name : movie.Name;
			movie.Year = Model.Year != default ? Model.Year : movie.Year;
			movie.Price = Model.Price != default ? Model.Price : movie.Price;

			context.MovieActors.RemoveRange(context.MovieActors.Where(ma => ma.MovieID == MovieID));
			foreach (int actor_ID in Model.ActorIDs) {
				if (!context.Actors.Any(a => a.ID == actor_ID)) throw new InvalidOperationException("Actor could not be found.");
				context.MovieActors.Add(new MovieActor { MovieID = MovieID, ActorID = actor_ID });
			}
			context.MovieDirectors.RemoveRange(context.MovieDirectors.Where(md => md.MovieID == MovieID));
			foreach (int director_ID in Model.DirectorIDs) {
				if (!context.Directors.Any(d => d.ID == director_ID)) throw new InvalidOperationException("Director could not be found.");
				context.MovieDirectors.Add(new MovieDirector { MovieID = MovieID, DirectorID = director_ID });
			}
			context.MovieGenres.RemoveRange(context.MovieGenres.Where(mg => mg.MovieID == MovieID));
			foreach (int genre_ID in Model.GenreIDs) {
				if (!context.Genres.Any(g => g.ID == genre_ID)) throw new InvalidOperationException("Genre could not be found.");
				context.MovieGenres.Add(new MovieGenre { MovieID = MovieID, GenreID = genre_ID });
			}
			context.SaveChanges();
		}
		public class UpdateMovieModel {
			public string? Name { get; set; }
			public int Year { get; set; }
			public double Price { get; set; }
			public List<int> ActorIDs { get; set; } = null!;
			public List<int> DirectorIDs { get; set; } = null!;
			public List<int> GenreIDs { get; set; } = null!;
		}
	}
}