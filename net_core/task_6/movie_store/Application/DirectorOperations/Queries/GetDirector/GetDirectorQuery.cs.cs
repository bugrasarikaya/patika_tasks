using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
			Director? director = context.Directors.Include(d => d.Movies).Where(d => d.ID == DirectorID).SingleOrDefault();
			if (director is null) throw new InvalidOperationException("Director could not be found.");
			GetDirectorViewModel view_model = mapper.Map<GetDirectorViewModel>(director);
			return view_model;
		}
		public class GetDirectorViewModel {
			public string? Name { get; set; }
			public string? Surname { get; set; }
			public string? Movies { get; set; }
		}
	}
}