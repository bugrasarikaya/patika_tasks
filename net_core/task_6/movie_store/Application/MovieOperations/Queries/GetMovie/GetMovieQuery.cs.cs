using AutoMapper;
using Microsoft.EntityFrameworkCore;
using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.MovieOperations.Queries.GetMovie {
	public class GetMovieQuery {
		private readonly IMovieStoreDbContext context;
		private readonly IMapper mapper;
		public int MovieID { get; set; }
		public GetMovieQuery(IMovieStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public GetMovieViewModel Handle() {
			Movie? movie = context.Movies.Include(m => m.Director).Include(m => m.Genres).Include(m => m.Actors).Where(m => m.ID == MovieID).SingleOrDefault();
			if (movie is null) throw new InvalidOperationException("Movie could not be found.");
			GetMovieViewModel view_model = mapper.Map<GetMovieViewModel>(movie);
			return view_model;
		}
		public class GetMovieViewModel {
			public string? Name { get; set; }
			public int Year { get; set; }
			public string? Genres { get; set; }
			public string? Director { get; set; }
			public string? Actors { get; set; }
			public double Price { get; set; }
		}
	}
}