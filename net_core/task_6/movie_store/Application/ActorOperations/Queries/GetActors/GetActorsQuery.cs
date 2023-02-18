using AutoMapper;
using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.ActorOperations.Queries.GetActors {
	public class GetActorsQuery {
		private readonly IMovieStoreDbContext context;
		private readonly IMapper mapper;
		public GetActorsQuery(IMovieStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public List<GetActorsViewModel> Handle() {
			List<Actor>? list_actor = context.Actors.OrderBy(a => a.ID).ToList();
			List<GetActorsViewModel> list_view_model = mapper.Map<List<GetActorsViewModel>>(list_actor);
			foreach (int actor_ID in list_actor.Select(la => la.ID)) {
				List<string> list_movie = new List<string>();
				foreach (int movie_ID in context.MovieActors.Where(ma => ma.ActorID == actor_ID).Select(m => m.MovieID)) list_movie.Add(context.Movies.SingleOrDefault(m => m.ID == movie_ID)!.Name!);
				list_view_model.SingleOrDefault(lvm => lvm.ID == actor_ID)!.Movies = string.Join(", ", list_movie);
			}
			return list_view_model;
		}
		public class GetActorsViewModel {
			public int ID { get; set; }
			public string? Name { get; set; }
			public string? Surname { get; set; }
			public string? Movies { get; set; }
		}
	}
}