using game_store.DBOperations;
using game_store.Entities;
namespace xUnitTests.TestSetup {
	public static class Games {
		public static void AddGames(this GameStoreDbContext context) {
			context.Games.AddRange(
				new Game { ID = 1, Name = "Vampire: The Masquerade - Bloodlines", Year = 2004, Price = 19.99 },
				new Game { ID = 2, Name = "Fallout: New Vegas", Year = 2010, Price = 9.99 }
			);
		}
	}
}