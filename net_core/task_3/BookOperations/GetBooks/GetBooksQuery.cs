using AutoMapper;
using task_3.DBOperations;
using static task_3.Common.GenerateEnum;
namespace task_3.BookOperations.GetBooks {
	public class GetBooksQuery {
		private readonly BookStoreDbContext _dbContext;
		private readonly IMapper _mapper;
		public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper) {
			_dbContext = dbContext;
			_mapper = mapper;
		}
		public List<BooksViewModel> Handle() {
			var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
			List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);
			return vm;
		}
	}
	public class BooksViewModel {
		public string Title { get; set; }
		public int PageCount { get; set; }
		public string PublishDate { get; set; }
		public string Genre { get; set; }
	}
}