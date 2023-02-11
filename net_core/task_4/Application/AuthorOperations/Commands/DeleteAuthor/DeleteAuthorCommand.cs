using Microsoft.EntityFrameworkCore;
using task_4.DBOperations;
namespace task_4.Application.AuthorOperations.Commands.DeleteAuthor {
	public class DeleteAuthorCommand {
		private readonly BookStoreDbContext _dbContext;
		public int AuthorID { get; set; }
		public DeleteAuthorCommand(BookStoreDbContext dbContext) {
			_dbContext = dbContext;
		}
		public void Handle() {
			var Author = _dbContext.Authors.SingleOrDefault(x => x.ID == AuthorID);
			if (Author is null) throw new InvalidOperationException("Silinecek yazar bulunamadı!");
			if(_dbContext.Books.Any(x => x.AuthorID == Author.ID)) throw new InvalidOperationException("Mevcut yazarın bir kitabı var.");
			_dbContext.Authors.Remove(Author);
			_dbContext.SaveChanges();
		}
	}
}