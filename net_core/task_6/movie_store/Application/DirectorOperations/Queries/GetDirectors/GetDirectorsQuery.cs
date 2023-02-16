using AutoMapper;
using Microsoft.EntityFrameworkCore;
using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.DirectorOperations.Queries.GetDirectors {
	public class GetDirectorsQuery {
		private readonly IMovieStoreDbContext context;
		private readonly IMapper mapper;
		public GetDirectorsQuery(IMovieStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public List<GetDirectorsViewModel> Handle() {
			List<Director>? director_list = context.Directors.Include(d => d.Movies).OrderBy(d => d.ID).ToList();
			List<GetDirectorsViewModel> view_model = mapper.Map<List<GetDirectorsViewModel>>(director_list);
			return view_model;
		}
		public class GetDirectorsViewModel {
			public string? Name { get; set; }
			public string? Surname { get; set; }
			public string? Movies { get; set; }
		}
	}
}