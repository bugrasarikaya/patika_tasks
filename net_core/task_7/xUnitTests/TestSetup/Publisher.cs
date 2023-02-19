using game_store.DBOperations;
using game_store.Entities;
namespace xUnitTests.TestSetup {
	public static class Publishers {
		public static void AddPublishers(this GameStoreDbContext context) {
			context.Publishers.AddRange(
				new Publisher { ID = 1, Name = "Activision", Year = 1979 },
				new Publisher { ID = 2, Name = "Bethesda Softworks", Year = 1986 }
			);
		}
	}
}