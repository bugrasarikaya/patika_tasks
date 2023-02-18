using AutoMapper;
using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.ActorOperations.Queries.GetActor {
	public class GetActorQuery {
		private readonly IMovieStoreDbContext context;
		private readonly IMapper mapper;
		public int ActorID { get; set; }
		public GetActorQuery(IMovieStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public GetActorViewModel Handle() {
			Actor? actor = context.Actors.Where(a => a.ID == ActorID).SingleOrDefault();
			if (actor is null) throw new InvalidOperationException("Actor could not be found.");
			GetActorViewModel view_model = mapper.Map<GetActorViewModel>(actor);
			List<string> list_movie = new List<string>();
			foreach (int movie_ID in context.MovieActors.Where(ma => ma.ActorID == ActorID).Select(ma => ma.MovieID)) list_movie.Add(context.Movies.SingleOrDefault(m => m.ID == movie_ID)!.Name!);
			view_model.Movies = string.Join(", ", list_movie);
			return view_model;
		}
		public class GetActorViewModel {
			public int ID { get; set; }
			public string? Name { get; set; }
			public string? Surname { get; set; }
			public string? Movies { get; set; }
		}
	}
}