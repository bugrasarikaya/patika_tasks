using AutoMapper;
using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.GenreOperations.Queries.GetGenre {
	public class GetGenreQuery {
		private readonly IMovieStoreDbContext context;
		private readonly IMapper mapper;
		public int GenreID { get; set; }
		public GetGenreQuery(IMovieStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public GetGenreViewModel Handle() {
			Genre? genre = context.Genres.Where(g => g.ID == GenreID).SingleOrDefault();
			if (genre is null) throw new InvalidOperationException("Genre could not be found.");
			GetGenreViewModel view_model = mapper.Map<GetGenreViewModel>(genre);
			return view_model;
		}
		public class GetGenreViewModel {
			public string? Name { get; set; }
		}
	}
}