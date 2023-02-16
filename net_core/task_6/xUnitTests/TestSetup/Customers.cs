using movie_store.DBOperations;
using movie_store.Entities;
namespace xUnitTests.TestSetup {
	public static class Customers {
		public static void AddCustomers(this MovieStoreDbContext context) {
			context.Customers.AddRange(
				new Customer { ID = 1, Name = "Sebastian", Surname = "Lacroix", Email = "sebastianlacroix@schrecknet.vtm", Password = "12345678" },
				new Customer { ID = 2, Name = "Bertram", Surname = "Tung", Email = "bertramtung@schrecknet.vtm", Password = "12345678" },
				new Customer { ID = 3, Name = "Velvet", Surname = "Velour", Email = "velvetvelour@schrecknet.vtm", Password = "12345678" }
			);
		}
	}
}