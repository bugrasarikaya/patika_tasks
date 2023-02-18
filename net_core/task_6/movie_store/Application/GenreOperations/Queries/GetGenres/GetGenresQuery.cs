using AutoMapper;
using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.GenreOperations.Queries.GetGenres {
	public class GetGenresQuery {
		private readonly IMovieStoreDbContext context;
		private readonly IMapper mapper;
		public GetGenresQuery(IMovieStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public List<GetGenresViewModel> Handle() {
			List<Genre>? list_genre = context.Genres.OrderBy(g => g.ID).ToList();
			List<GetGenresViewModel> view_model = mapper.Map<List<GetGenresViewModel>>(list_genre);
			return view_model;
		}
		public class GetGenresViewModel {
			public int ID { get; set; }
			public string? Name { get; set; }
		}
	}
}