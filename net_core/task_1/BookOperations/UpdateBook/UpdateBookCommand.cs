﻿using task_1.DBOperations;
namespace task_1.BookOperations.UpdateBook {
	public class UpdateBookCommand {
		public UpdateBookModel Model { get; set; }
		private readonly BookStoreDbContext _dbContext;
		public UpdateBookCommand(BookStoreDbContext dbContext) {
			_dbContext = dbContext;
		}
		public void Handle(int id) {
			var book = _dbContext.Books.SingleOrDefault(x => x.Id == id);
			if (book is null) throw new InvalidOperationException("Kitap mevcut değil");
			book.Title = Model.Title;
			book.PublishDate = Model.PublishDate;
			book.PageCount = Model.PageCount;
			book.GenreId = Model.GenreId;
			_dbContext.SaveChanges();
		}
	}
	public class UpdateBookModel {
		public string Title { get; set; }
		public int GenreId { get; set; }
		public int PageCount { get; set; }
		public DateTime PublishDate { get; set; }
	}
}