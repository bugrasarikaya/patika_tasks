using movie_store.DBOperations;
using movie_store.Entities;
namespace xUnitTests.TestSetup {
	public static class OrderMovies {
		public static void AddOrderMovies(this MovieStoreDbContext context) {
			context.OrderMovies.AddRange(
				new OrderMovie { ID = 1, OrderID = 1, MovieID = 2 },
				new OrderMovie { ID = 2, OrderID = 2, MovieID = 1 },
				new OrderMovie { ID = 3, OrderID = 2, MovieID = 2 },
				new OrderMovie { ID = 4, OrderID = 3, MovieID = 3 }
			);
		}
	}
}