using Microsoft.EntityFrameworkCore;
using task_4.DBOperations;
namespace task_4.Application.BookOperations.Commands.DeleteBook {
	public class DeleteBookCommand {
		private readonly IBookStoreDbContext _dbContext;
		public int BookID { get; set; }
		public DeleteBookCommand(IBookStoreDbContext dbContext) {
			_dbContext = dbContext;
		}
		public void Handle() {
			var book = _dbContext.Books.SingleOrDefault(x => x.ID == BookID);
			if (book is null) throw new InvalidOperationException("Silinecek kitap bulunamadı!");
			_dbContext.Books.Remove(book);
			_dbContext.SaveChanges();
		}
	}
}