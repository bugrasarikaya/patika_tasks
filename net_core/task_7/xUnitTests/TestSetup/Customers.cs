using game_store.DBOperations;
using game_store.Entities;
namespace xUnitTests.TestSetup {
	public static class Customers {
		public static void AddCustomers(this GameStoreDbContext context) {
			context.Customers.AddRange(
				new Customer { ID = 1, Email = "sebastianlacroix@schrecknet.vtm", Password = "12345678" },
				new Customer { ID = 2, Email = "bertramtung@schrecknet.vtm", Password = "12345678" },
				new Customer { ID = 3, Email = "velvetvelour@schrecknet.vtm", Password = "12345678" }
			);
		}
	}
}