using AutoMapper;
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
			List<Director>? list_director = context.Directors.OrderBy(d => d.ID).ToList();
			List<GetDirectorsViewModel> list_view_model = mapper.Map<List<GetDirectorsViewModel>>(list_director);
			foreach (int director_ID in list_director.Select(ld => ld.ID)) {
				List<string> list_movie = new List<string>();
				foreach (int movie_ID in context.MovieDirectors.Where(md => md.DirectorID == director_ID).Select(md => md.MovieID)) list_movie.Add(context.Movies.SingleOrDefault(m => m.ID == movie_ID)!.Name!);
				list_view_model.SingleOrDefault(lvm => lvm.ID == director_ID)!.Movies = string.Join(", ", list_movie);
			}
			return list_view_model;
		}
		public class GetDirectorsViewModel {
			public int ID { get; set; }
			public string? Name { get; set; }
			public string? Surname { get; set; }
			public string? Movies { get; set; }
		}
	}
}