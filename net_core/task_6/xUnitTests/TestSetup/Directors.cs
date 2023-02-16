using movie_store.DBOperations;
using movie_store.Entities;
namespace xUnitTests.TestSetup {
	public static class Directors {
		public static void AddDirectors(this MovieStoreDbContext context) {
			context.Directors.AddRange(
				new Director { ID = 1, Name = "Ivan", Surname = "Reitman" },
				new Director { ID = 2, Name = "Christopher", Surname = "Nolan" },
				new Director { ID = 3, Name = "Peter", Surname = "Medak" }
			);
		}
	}
}