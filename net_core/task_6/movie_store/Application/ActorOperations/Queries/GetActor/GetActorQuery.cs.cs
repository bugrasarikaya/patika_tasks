using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
			Actor? actor = context.Actors.Include(a => a.Movies).Where(a => a.ID == ActorID).SingleOrDefault();
			if (actor is null) throw new InvalidOperationException("Actor could not be found.");
			GetActorViewModel view_model = mapper.Map<GetActorViewModel>(actor);
			return view_model;
		}
		public class GetActorViewModel {
			public string? Name { get; set; }
			public string? Surname { get; set; }
			public string? Movies { get; set; }
		}
	}
}