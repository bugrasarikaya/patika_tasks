using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.DirectorOperations.Commands.UpdateDirector {
	public class UpdateDirectorCommand {
		public int DirectorID { get; set; }
		public UpdateDirectorModel Model { get; set; } = null!;
		private readonly IMovieStoreDbContext context;
		public UpdateDirectorCommand(IMovieStoreDbContext context) {
			this.context = context;
		}
		public void Handle() {
			Director? director = context.Directors.SingleOrDefault(m => m.ID == DirectorID);
			if (director == null) throw new InvalidOperationException("Director could not be found.");
			director.Name = Model.Name != default ? Model.Name : director.Name;
			director.Surname = Model.Surname != default ? Model.Surname : director.Surname;
			foreach (Movie director_movie in director.Movies.ToList()) {
				bool existing_movie = false;
				foreach (int movie_ID in Model.MovieIDs) {
					Movie? movie = context.Movies.SingleOrDefault(m => m.ID == movie_ID);
					if (movie == null) throw new InvalidOperationException("Movie could not be found.");
					if (movie.Director != null && movie.Director.ID != director.ID) movie.Director = director;
					if (!director.Movies.Any(a => a.ID == movie_ID)) director.Movies.Add(movie);
					if (director_movie.ID == movie_ID) existing_movie |= true;
				}
				if (!existing_movie) {
					director_movie.Director = null;
					director.Movies.Remove(director_movie);
				}
			}
			context.SaveChanges();
		}
		public class UpdateDirectorModel {
			public string? Name { get; set; }
			public string? Surname { get; set; }
			public List<int> MovieIDs { get; set; } = null!;
		}
	}
}