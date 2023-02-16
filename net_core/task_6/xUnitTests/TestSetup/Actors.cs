using movie_store.DBOperations;
using movie_store.Entities;
namespace xUnitTests.TestSetup {
	public static class Actors {
		public static void AddActors(this MovieStoreDbContext context) {
			context.Actors.AddRange(
				new Actor { ID = 1, Name = "Bill", Surname = "Murray" },
				new Actor { ID = 2, Name = "Christian", Surname = "Bale" },
				new Actor { ID = 3, Name = "Gary", Surname = "Oldman" }
			);
		}
	}
}