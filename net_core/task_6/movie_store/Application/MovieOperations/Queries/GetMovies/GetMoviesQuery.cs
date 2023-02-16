using AutoMapper;
using Microsoft.EntityFrameworkCore;
using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.MovieOperations.Queries.GetMovies {
	public class GetMoviesQuery {
		private readonly IMovieStoreDbContext context;
		private readonly IMapper mapper;
		public GetMoviesQuery(IMovieStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public List<GetMoviesViewModel> Handle() {
			List<Movie>? movie_list = context.Movies.Include(m => m.Director).Include(m => m.Genres).Include(m => m.Actors).OrderBy(m => m.ID).ToList();
			List<GetMoviesViewModel> view_model = mapper.Map<List<GetMoviesViewModel>>(movie_list);
			return view_model;
		}
		public class GetMoviesViewModel {
			public string? Name { get; set; }
			public int Year { get; set; }
			public string? Genres { get; set; }
			public string? Director { get; set; }
			public string? Actors { get; set; }
			public double Price { get; set; }
		}
	}
}