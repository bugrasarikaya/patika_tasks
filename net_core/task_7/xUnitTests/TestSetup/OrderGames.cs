using game_store.DBOperations;
using game_store.Entities;
namespace xUnitTests.TestSetup {
	public static class OrderGames {
		public static void AddOrderGames(this GameStoreDbContext context) {
			context.OrderGames.AddRange(
				new OrderGame { ID = 1, OrderID = 1, GameID = 1 },
				new OrderGame { ID = 2, OrderID = 1, GameID = 2 },
				new OrderGame { ID = 3, OrderID = 2, GameID = 2 }

			);
		}
	}
}