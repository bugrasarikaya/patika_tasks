using AutoMapper;
using Microsoft.EntityFrameworkCore;
using game_store.Common;
using game_store.DBOperations;
namespace xUnitTests.TestSetup {
	public class CommonTestFixture {
		public GameStoreDbContext Context { get; set; }
		public IMapper Mapper { get; set; }
		public CommonTestFixture() {
			var options = new DbContextOptionsBuilder<GameStoreDbContext>().UseInMemoryDatabase(databaseName: "GameStoreTestDb").Options;
			Context = new GameStoreDbContext(options);
			Context.Database.EnsureCreated();
			Context.AddDevelopers();
			Context.AddCustomers();
			Context.AddPublishers();
			Context.AddGameDevelopers();
			Context.AddGamePublishers();
			Context.AddGames();
			Context.AddOrderGames();
			Context.AddOrders();
			Context.SaveChanges();
			Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();
		}
	}
}