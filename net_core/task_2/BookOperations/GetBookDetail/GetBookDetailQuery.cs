using task_2.DBOperations;
using static task_2.Common.GenerateEnum;
namespace task_2.BookOperations.GetBookDetail {
	public class GetBookDetailQuery {
		private readonly BookStoreDbContext _dbContext;
		public int BookID { get; set; }
		public GetBookDetailQuery(BookStoreDbContext dbContext) {
			_dbContext = dbContext;
		}
		public BookDetailViewModel Handle(int id) {
			var book = _dbContext.Books.Where(book => book.Id == BookID).SingleOrDefault();
			if (book is null) throw new InvalidOperationException("Kitap Bulunamadı!");
			BookDetailViewModel vm = new BookDetailViewModel();
			vm.Title = book.Title;
			vm.PageCount = book.PageCount;
			vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/YY");
			vm.Genre = ((GenreEnum)book.GenreId).ToString();
			return vm;
		}
	}
	public class BookDetailViewModel {
		public string Title { get; set; }
		public string Genre { get; set; }
		public int PageCount { get; set; }
		public string PublishDate { get; set; }
	}
}