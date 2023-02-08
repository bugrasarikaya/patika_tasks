using Microsoft.EntityFrameworkCore;
using task_2.DBOperations;
namespace task_2.BookOperations.DeleteBook {
	public class DeleteBookCommand {
		private readonly BookStoreDbContext _dbContext;
		public int BookID { get; set; }
		public DeleteBookCommand(BookStoreDbContext dbContext) {
			_dbContext = dbContext;
		}
		public void Handle() {
			var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookID);
			if (book is null) throw new InvalidOperationException("Silinecek kitap bulunamadı!");
			_dbContext.Books.Remove(book);
			_dbContext.SaveChanges();
		}
	}
}