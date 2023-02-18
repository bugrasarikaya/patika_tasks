using Microsoft.EntityFrameworkCore;
using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.ActorOperations.Commands.DeleteActor {
	public class DeleteActorCommand {
		private readonly IMovieStoreDbContext context;
		public int ActorID { get; set; }
		public DeleteActorCommand(IMovieStoreDbContext context) {
			this.context = context;
		}
		public void Handle() {
			Actor? actor = context.Actors.SingleOrDefault(m => m.ID == ActorID);
			if (actor == null) throw new InvalidOperationException("Actor could not be found.");
			if (context.MovieActors.Any(m => m.ActorID == ActorID)) throw new InvalidOperationException("Actor exists in a movie.");
			context.Actors.Remove(actor);
			context.SaveChanges();
		}
	}
}