using AutoMapper;
using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.ActorOperations.Commands.CreateActor {
	public class CreateActorCommand {
		public CreateActorModel Model { get; set; } = null!;
		private readonly IMovieStoreDbContext context;
		private readonly IMapper mapper;
		public CreateActorCommand(IMovieStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public void Handle() {
			Actor? actor = context.Actors.SingleOrDefault(a => a.Name == Model.Name && a.Surname == Model.Surname);
			if (actor != null) throw new InvalidOperationException("Actor already exists.");
			actor = mapper.Map<Actor>(Model);
			context.Actors.Add(actor);
			context.SaveChanges();
		}
		public class CreateActorModel {
			public string? Name { get; set; }
			public string? Surname { get; set; }
		}
	}
}