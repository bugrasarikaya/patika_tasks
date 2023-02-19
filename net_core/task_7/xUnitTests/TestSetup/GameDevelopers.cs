using game_store.DBOperations;
using game_store.Entities;
namespace xUnitTests.TestSetup {
	public static class GameDevelopers {
		public static void AddGameDevelopers(this GameStoreDbContext context) {
			context.GameDevelopers.AddRange(
				new GameDeveloper { ID = 1, GameID = 1, DeveloperID = 1 },
				new GameDeveloper { ID = 2, GameID = 2, DeveloperID = 2 }
			);
		}
	}
}