using game_store.DBOperations;
using game_store.Entities;
namespace xUnitTests.TestSetup {
	public static class GamePublishers {
		public static void AddGamePublishers(this GameStoreDbContext context) {
			context.GamePublishers.AddRange(
				new GamePublisher { ID = 1, GameID = 1, PublisherID = 1 },
				new GamePublisher { ID = 2, GameID = 2, PublisherID = 2 }
			);
		}
	}
}