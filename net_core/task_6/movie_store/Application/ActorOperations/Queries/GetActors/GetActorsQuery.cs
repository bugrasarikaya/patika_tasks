using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
			List<Actor>? Actor_list = context.Actors.Include(a => a.Movies).OrderBy(a => a.ID).ToList();
			List<GetActorsViewModel> view_model = mapper.Map<List<GetActorsViewModel>>(Actor_list);
			return view_model;
		}
		public class GetActorsViewModel {
			public string? Name { get; set; }
			public string? Surname { get; set; }
			public string? Movies { get; set; }
		}
	}
}