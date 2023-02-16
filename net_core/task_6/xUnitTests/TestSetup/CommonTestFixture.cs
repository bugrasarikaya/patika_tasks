using AutoMapper;
using Microsoft.EntityFrameworkCore;
using movie_store.Common;
using movie_store.DBOperations;
namespace xUnitTests.TestSetup {
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