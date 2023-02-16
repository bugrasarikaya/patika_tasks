using AutoMapper;
using Microsoft.EntityFrameworkCore;
using movie_store.Common;
using movie_store.DBOperations;
namespace xUnitTests.TestSetup {
	public class CommonTestFixture {
		public MovieStoreDbContext context { get; set; }
		public IMapper Mapper { get; set; }
		public CommonTestFixture() {
			var options = new DbContextOptionsBuilder<MovieStoreDbContext>().UseInMemoryDatabase(databaseName: "BookStoreTestDb").Options;
			context = new MovieStoreDbContext(options);
			context.Database.EnsureCreated();
			context.AddActors();
			context.AddCustomers();
			context.AddDirectors();
			context.AddGenres();
			context.AddMovies();
			context.AddOrders();
			context.SaveChanges();

			Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();
		}
	}
}