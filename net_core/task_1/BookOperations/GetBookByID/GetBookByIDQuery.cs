using task_1.DBOperations;
using static task_1.Common.GenerateEnum;
namespace task_1.BookOperations.GetBookByID {
	public class GetBookByIDQuery {
		private readonly BookStoreDbContext _dbContext;
		public GetBookByIDQuery(BookStoreDbContext dbContext) {
			_dbContext = dbContext;
		}
		public BooksViewModel Handle(int id) {
			var book = _dbContext.Books.SingleOrDefault(x => x.Id == id);
			BooksViewModel vm = new BooksViewModel();
			vm.Title = book.Title;
			vm.Genre = ((GenreEnum)book.GenreId).ToString();
			vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/YY");
			vm.PageCount = book.PageCount;
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