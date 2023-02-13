using AutoMapper;
using task_4.DBOperations;
namespace task_4.Application.GenreOperations.Queries.GetGenres {
	public class GetGenresQuery {
		public readonly IBookStoreDbContext _context;
		public readonly IMapper _mapper;
		public GetGenresQuery(IBookStoreDbContext context, IMapper mapper) {
			_context = context;
			_mapper = mapper;
		}
		public List<GenresViewModel> Handle() {
			var genres = _context.Genres.Where(x => x.IsActive).OrderBy(x => x.ID);
			List<GenresViewModel> returnObj = _mapper.Map<List<GenresViewModel>>(genres);
			return returnObj;
		}
	}
	public class GenresViewModel {
		public int ID { get; set; }
		public string Name { get; set; }
	}
}