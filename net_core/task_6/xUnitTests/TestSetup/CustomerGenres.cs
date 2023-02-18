using movie_store.DBOperations;
using movie_store.Entities;
namespace xUnitTests.TestSetup {
	public static class CustomerGenres {
		public static void AddCustomerGenres(this MovieStoreDbContext context) {
			context.CustomerGenres.AddRange(
				new CustomerGenre { ID = 1, CustomerID = 1, GenreID = 1 },
				new CustomerGenre { ID = 2, CustomerID = 1, GenreID = 2 },
				new CustomerGenre { ID = 3, CustomerID = 2, GenreID = 1 },
				new CustomerGenre { ID = 5, CustomerID = 2, GenreID = 2 },
				new CustomerGenre { ID = 6, CustomerID = 3, GenreID = 2 },
				new CustomerGenre { ID = 7, CustomerID = 3, GenreID = 3 }
			);
		}
	}
}