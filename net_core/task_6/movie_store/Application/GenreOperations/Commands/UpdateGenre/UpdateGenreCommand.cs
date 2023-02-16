using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.GenreOperations.Commands.UpdateGenre {
	public class UpdateGenreCommand {
		public int GenreID { get; set; }
		public UpdateGenreModel Model { get; set; } = null!;
		private readonly IMovieStoreDbContext context;
		public UpdateGenreCommand(IMovieStoreDbContext context) {
			this.context = context;
		}
		public void Handle() {
			Genre? Genre = context.Genres.SingleOrDefault(m => m.ID == GenreID);
			if (Genre == null) throw new InvalidOperationException("Genre could not be found.");
			Genre.Name = Model.Name != default ? Model.Name : Genre.Name;
			context.SaveChanges();
		}
		public class UpdateGenreModel {
			public string? Name { get; set; }
		}
	}
}