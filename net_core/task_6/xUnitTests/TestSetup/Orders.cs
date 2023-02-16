using movie_store.DBOperations;
using movie_store.Entities;
namespace xUnitTests.TestSetup {
	public static class Orders {
		public static void AddOrders(this MovieStoreDbContext context) {
			context.Orders.AddRange(
				new Order { ID = 1, DateTime = new DateTime(2000, 01, 01) },
				new Order { ID = 2, DateTime = new DateTime(2000, 01, 02) },
				new Order { ID = 3, DateTime = new DateTime(2000, 01, 03) }
			);
		}
	}
}