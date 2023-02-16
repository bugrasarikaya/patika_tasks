using movie_store.DBOperations;
using movie_store.Entities;
namespace xUnitTests.TestSetup {
	public static class Authors {
		public static void AddAuthors(this BookStoreDbContext context) {
			context.Authors.AddRange(
				new Author { Name = "Eric", Surname = "Ries", DateofBirth = new DateTime(1978, 10, 22) },
				new Author { Name = "Charlotte Perkins", Surname = "Gilman", DateofBirth = new DateTime(2860, 7, 3) },
				new Author { Name = "Frank", Surname = "Herbert", DateofBirth = new DateTime(1920, 10, 8) }
			);
		}
	}
}