using task_3.DBOperations;
namespace task_3.BookOperations.UpdateBook {
	public class UpdateBookCommand {
		public int BookID { get; set; }
		public UpdateBookModel Model { get; set; }
		private readonly BookStoreDbContext _context;
		public UpdateBookCommand(BookStoreDbContext dbContext) {
			_context = dbContext;
		}
		public void Handle() {
			var book = _context.Books.SingleOrDefault(x => x.Id == BookID);
			if (book is null) throw new InvalidOperationException("Güncellencek Kitap Bulunamadı!");
			book.GenreID = Model.GenreID != default ? Model.GenreID : book.GenreID;
			book.Title = Model.Title != default ? Model.Title : book.Title;
			_context.SaveChanges();
		}
	}
	public class UpdateBookModel {
		public string Title { get; set; }
		public int GenreID { get; set; }
	}
}