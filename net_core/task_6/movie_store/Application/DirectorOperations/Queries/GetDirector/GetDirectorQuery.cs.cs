using AutoMapper;
using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.DirectorOperations.Queries.GetDirector {
	public class GetDirectorQuery {
		private readonly IMovieStoreDbContext context;
		private readonly IMapper mapper;
		public int DirectorID { get; set; }
		public GetDirectorQuery(IMovieStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public GetDirectorViewModel Handle() {
			Director? director = context.Directors.Where(d => d.ID == DirectorID).SingleOrDefault();
			if (director is null) throw new InvalidOperationException("Director could not be found.");
			GetDirectorViewModel view_model = mapper.Map<GetDirectorViewModel>(director);
			List<string> list_movie = new List<string>();
			foreach (int movie_ID in context.MovieDirectors.Where(md => md.DirectorID == DirectorID).Select(md => md.MovieID)) list_movie.Add(context.Movies.SingleOrDefault(m => m.ID == movie_ID)!.Name!);
			view_model.Movies = string.Join(", ", list_movie);
			return view_model;
		}
		public class GetDirectorViewModel {
			public int ID { get; set; }
			public string? Name { get; set; }
			public string? Surname { get; set; }
			public string? Movies { get; set; }
		}
	}
}