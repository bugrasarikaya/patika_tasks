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
			List<Genre>? genre_list = context.Genres.OrderBy(g => g.ID).ToList();
			List<GetGenresViewModel> view_model = mapper.Map<List<GetGenresViewModel>>(genre_list);
			return view_model;
		}
		public class GetGenresViewModel {
			public string? Name { get; set; }
		}
	}
}