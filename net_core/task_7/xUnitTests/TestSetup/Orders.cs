using game_store.DBOperations;
using game_store.Entities;
namespace xUnitTests.TestSetup {
	public static class Orders {
		public static void AddOrders(this GameStoreDbContext context) {
			context.Orders.AddRange(
				new Order { ID = 1, CustomerEmail = "sebastianlacroix@schrecknet.vtm", Cost = 19.99 + 9.99, DateTime = new DateTime(2020, 01, 01) },
				new Order { ID = 2, CustomerEmail = "bertramtung@schrecknet.vtm", Cost = 9.99, DateTime = new DateTime(2020, 01, 02) }
			);
		}
	}
}