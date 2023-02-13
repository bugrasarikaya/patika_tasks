using AutoMapper;
using task_4.DBOperations;
namespace task_4.Application.GenreOperations.Queries.GetGenreDetail {
	public class GetGenreDetailQuery {
		public int GenreID { get; set; }
		public readonly IBookStoreDbContext _context;
		public readonly IMapper _mapper;
		public GetGenreDetailQuery(IBookStoreDbContext context, IMapper mapper) {
			_context = context;
			_mapper = mapper;
		}
		public GenreDetailViewModel Handle() {
			var genre = _context.Genres.SingleOrDefault(x => x.IsActive && x.ID == GenreID);
			GenreDetailViewModel returnObj = _mapper.Map<GenreDetailViewModel>(genre);
			if (genre is null) throw new InvalidOperationException("Kitap Türü Bulunamadı!");
			return _mapper.Map<GenreDetailViewModel>(genre);
		}
	}
	public class GenreDetailViewModel {
		public int ID { get; set; }
		public string Name { get; set; }
	}
}