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
			context.MovieActors.RemoveRange(context.MovieActors.Where(ma => ma.MovieID == MovieID));
			context.MovieDirectors.RemoveRange(context.MovieDirectors.Where(md => md.MovieID == MovieID));
			context.MovieGenres.RemoveRange(context.MovieGenres.Where(mg => mg.MovieID == MovieID));
			context.Movies.Remove(movie);
			context.SaveChanges();
		}
	}
}