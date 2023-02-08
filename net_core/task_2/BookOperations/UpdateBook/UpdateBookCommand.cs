using task_2.DBOperations;
namespace task_2.BookOperations.UpdateBook {
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
			book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
			book.Title = Model.Title != default ? Model.Title : book.Title;
			_context.SaveChanges();
		}
	}
	public class UpdateBookModel {
		public string Title { get; set; }
		public int GenreId { get; set; }
	}
}