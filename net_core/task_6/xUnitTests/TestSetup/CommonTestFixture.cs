using AutoMapper;
using Microsoft.EntityFrameworkCore;
using movie_store.Common;
using movie_store.DBOperations;
namespace xUnitTests.TestSetup {
	public class CommonTestFixture {
		public MovieStoreDbContext Context { get; set; }
		public IMapper Mapper { get; set; }
		public CommonTestFixture() {
			var options = new DbContextOptionsBuilder<MovieStoreDbContext>().UseInMemoryDatabase(databaseName: "BookStoreTestDb").Options;
			Context = new MovieStoreDbContext(options);
			Context.Database.EnsureCreated();
			Context.AddActors();
			Context.AddCustomerGenres();
			Context.AddCustomers();
			Context.AddDirectors();
			Context.AddGenres();
			Context.AddMovieActors();
			Context.AddMovieDirectors();
			Context.AddMovieGenres();
			Context.AddMovies();
			Context.AddOrderMovies();
			Context.AddOrders();
			Context.SaveChanges();
			Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();
		}
	}
}