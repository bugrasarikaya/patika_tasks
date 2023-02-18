using movie_store.DBOperations;
using movie_store.Entities;
namespace xUnitTests.TestSetup {
	public static class Orders {
		public static void AddOrders(this MovieStoreDbContext context) {
			context.Orders.AddRange(
				new Order { ID = 1, CustomerID = 1, Customer = "Sebastian Lacroix", CustomerEmail = "sebastianlacroix@schrecknet.vtm", Cost = 4.99, DateTime = new DateTime(2020, 01, 01) },
				new Order { ID = 2, CustomerID = 2, Customer = "Bertram Tung", CustomerEmail = "bertramtung@schrecknet.vtm", Cost = 4.99 + 8.99, DateTime = new DateTime(2020, 01, 02) },
				new Order { ID = 3, CustomerID = 3, Customer = "Velvet Velour", CustomerEmail = "velvetvelour@schrecknet.vtm", Cost = 4.99, DateTime = new DateTime(2020, 01, 03) }
			);
		}
	}
}