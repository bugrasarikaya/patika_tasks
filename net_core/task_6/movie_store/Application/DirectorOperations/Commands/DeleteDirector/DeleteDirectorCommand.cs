using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.DirectorOperations.Commands.DeleteDirector {
	public class DeleteDirectorCommand {
		private readonly IMovieStoreDbContext context;
		public int DirectorID { get; set; }
		public DeleteDirectorCommand(IMovieStoreDbContext context) {
			this.context = context;
		}
		public void Handle() {
			Director? Director = context.Directors.SingleOrDefault(m => m.ID == DirectorID);
			if (Director == null) throw new InvalidOperationException("Director could not be found.");
			if (context.MovieDirectors.Any(md => md.DirectorID == DirectorID)) throw new InvalidOperationException("Director exists in a movie.");
			context.Directors.Remove(Director);
			context.SaveChanges();
		}
	}
}