using game_store.DBOperations;
using game_store.Entities;
namespace xUnitTests.TestSetup {
	public static class Developers {
		public static void AddDevelopers(this GameStoreDbContext context) {
			context.Developers.AddRange(
				new Developer { ID = 1, Name = "Troika Games", Year = 1998 },
				new Developer { ID = 2, Name = "Obsidian Entertainment", Year = 2003 }
			);
		}
	}
}