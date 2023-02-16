using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.ActorOperations.Commands.UpdateActor {
	public class UpdateActorCommand {
		public int ActorID { get; set; }
		public UpdateActorModel Model { get; set; } = null!;
		private readonly IMovieStoreDbContext context;
		public UpdateActorCommand(IMovieStoreDbContext context) {
			this.context = context;
		}
		public void Handle() {
			Actor? actor = context.Actors.SingleOrDefault(m => m.ID == ActorID);
			if (actor == null) throw new InvalidOperationException("Actor could not be found.");
			actor.Name = Model.Name != default ? Model.Name : actor.Name;
			actor.Surname = Model.Surname != default ? Model.Surname : actor.Surname;
			foreach (Movie actor_movie in actor.Movies.ToList()) {
				bool existing_movie = false;
				foreach (int movie_ID in Model.MovieIDs) {
					Movie? movie = context.Movies.SingleOrDefault(m => m.ID == movie_ID);
					if (movie == null) throw new InvalidOperationException("Movie could not be found.");
					if (!movie.Actors.Any(m => m.ID == actor.ID)) movie.Actors.Add(actor);
					if (!actor.Movies.Any(a => a.ID == movie_ID)) actor.Movies.Add(movie);
					if (actor_movie.ID == movie_ID) existing_movie |= true;
				}
				if (!existing_movie) {
					actor_movie.Actors.Remove(actor);
					actor.Movies.Remove(actor_movie);
				}
			}
			context.SaveChanges();
		}
		public class UpdateActorModel {
			public string? Name { get; set; }
			public string? Surname { get; set; }
			public List<int> MovieIDs { get; set; } = null!;
		}
	}
}