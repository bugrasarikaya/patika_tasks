using AutoMapper;
using task_4.DBOperations;
using task_4.Entities;
namespace task_4.Application.BookOperations.Commands.CreateBook {
	public class CreateBookCommand {
		public CreateBookModel Model { get; set; }
		private readonly IBookStoreDbContext _dbContext;
		private readonly IMapper _mapper;
		public CreateBookCommand(IBookStoreDbContext dbCOntext, IMapper mapper) {
			_dbContext = dbCOntext;
			_mapper = mapper;
		}
		public void Handle() {
			var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);
			if (book is not null) throw new InvalidOperationException("Kitap zaten mevcut.");
			book = _mapper.Map<Book>(Model);
			_dbContext.Books.Add(book);
			_dbContext.SaveChanges();
		}
		public class CreateBookModel {
			public string Title { get; set; }
			public int AuthorID { get; set; }
			public int GenreID { get; set; }
			public int PageCount { get; set; }
			public DateTime PublishDate { get; set; }
		}
	}
}