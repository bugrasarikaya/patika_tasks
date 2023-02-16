using Microsoft.EntityFrameworkCore;
using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.MovieOperations.Commands.DeleteMovie {
	public class DeleteMovieCommand {
		private readonly IMovieStoreDbContext context;
		public int MovieID { get; set; }
		public DeleteMovieCommand(IMovieStoreDbContext context) {
			this.context = context;
		}
		public void Handle() {
			Movie? movie = context.Movies.SingleOrDefault(m => m.ID == MovieID);
			if (movie == null) throw new InvalidOperationException("Movie could not be found.");
			if (movie.Director != null) context.Directors.SingleOrDefault(d => d.ID == movie.Director.ID)!.Movies.Remove(movie);
			if (movie.Actors != null && movie.Actors.Count > 0) {
				List<Actor> list_actor = context.Actors.Where(a => a.Movies.Any(m => m.ID == MovieID)).ToList();
				foreach (Actor actor in list_actor) actor.Movies.Remove(movie);
			}
			context.Movies.Remove(movie);
			context.SaveChanges();
		}
	}
}