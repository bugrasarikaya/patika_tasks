using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.GenreOperations.Commands.DeleteGenre {
	public class DeleteGenreCommand {
		private readonly IMovieStoreDbContext context;
		public int GenreID { get; set; }
		public DeleteGenreCommand(IMovieStoreDbContext context) {
			this.context = context;
		}
		public void Handle() {
			Genre? genre = context.Genres.SingleOrDefault(g => g.ID == GenreID);
			if (genre == null) throw new InvalidOperationException("Genre could not be found.");
			if (context.MovieGenres.Any(mg => mg.GenreID == GenreID)) throw new InvalidOperationException("Genre exists in a movie.");
			context.Genres.Remove(genre);
			context.SaveChanges();
		}
	}
}