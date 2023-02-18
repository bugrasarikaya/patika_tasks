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
			if (context.Actors.Any(a => a.Name == actor.Name && a.Surname == actor.Surname)) throw new InvalidOperationException("Actor already exists.");
			context.SaveChanges();
		}
		public class UpdateActorModel {
			public string? Name { get; set; }
			public string? Surname { get; set; }
		}
	}
}