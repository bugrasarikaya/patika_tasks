using AutoMapper;
using Microsoft.EntityFrameworkCore;
using task_4.Common;
using task_4.DBOperations;
namespace task_5.TestSetup {
	public class CommonTestFixture {
		public BookStoreDbContext Context { get; set; }
		public IMapper Mapper { get; set; }
		public CommonTestFixture() {
			var options = new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase(databaseName: "BookStoreTestDb").Options;
			Context = new BookStoreDbContext(options);
			Context.Database.EnsureCreated();
			Context.AddAuthors();
			Context.AddBooks();
			Context.AddGenres();
			Context.SaveChanges();
			Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();
		}
	}
}