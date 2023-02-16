using movie_store.DBOperations;
namespace xUnitTests.TestSetup {
	public static class Relations {
		public static void AddRelations(this MovieStoreDbContext context) {
			context.Actors.SingleOrDefault(a => a.ID == 1)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 1)!); // Applying actor relations.
			context.Actors.SingleOrDefault(a => a.ID == 2)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 2)!);
			context.Actors.SingleOrDefault(a => a.ID == 3)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 2)!);
			context.Actors.SingleOrDefault(a => a.ID == 3)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 3)!);
			context.Customers.SingleOrDefault(c => c.ID == 1)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 2)!); // Applying customer relations.
			context.Customers.SingleOrDefault(c => c.ID == 1)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 1)!);
			context.Customers.SingleOrDefault(c => c.ID == 1)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 2)!);
			context.Customers.SingleOrDefault(c => c.ID == 2)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 1)!);
			context.Customers.SingleOrDefault(c => c.ID == 2)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 2)!);
			context.Customers.SingleOrDefault(c => c.ID == 2)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 1)!);
			context.Customers.SingleOrDefault(c => c.ID == 2)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 2)!);
			context.Customers.SingleOrDefault(c => c.ID == 3)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 3)!);
			context.Customers.SingleOrDefault(c => c.ID == 3)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 2)!);
			context.Customers.SingleOrDefault(c => c.ID == 3)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 3)!);
			context.Directors.SingleOrDefault(d => d.ID == 1)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 1)!); // Applying director relations.
			context.Directors.SingleOrDefault(d => d.ID == 2)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 2)!);
			context.Directors.SingleOrDefault(d => d.ID == 3)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 3)!);
			context.Movies.SingleOrDefault(m => m.ID == 1)!.Actors.Add(context.Actors.SingleOrDefault(a => a.ID == 1)!); // Applying movie relations.
			context.Movies.SingleOrDefault(m => m.ID == 1)!.Director = context.Directors.SingleOrDefault(a => a.ID == 1)!;
			context.Movies.SingleOrDefault(m => m.ID == 1)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 1)!);
			context.Movies.SingleOrDefault(m => m.ID == 2)!.Actors.Add(context.Actors.SingleOrDefault(a => a.ID == 2)!);
			context.Movies.SingleOrDefault(m => m.ID == 2)!.Actors.Add(context.Actors.SingleOrDefault(a => a.ID == 3)!);
			context.Movies.SingleOrDefault(m => m.ID == 2)!.Director = context.Directors.SingleOrDefault(a => a.ID == 2)!;
			context.Movies.SingleOrDefault(m => m.ID == 2)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 1)!);
			context.Movies.SingleOrDefault(m => m.ID == 2)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 2)!);
			context.Movies.SingleOrDefault(m => m.ID == 3)!.Actors.Add(context.Actors.SingleOrDefault(a => a.ID == 3)!);
			context.Movies.SingleOrDefault(m => m.ID == 3)!.Director = context.Directors.SingleOrDefault(a => a.ID == 3)!;
			context.Movies.SingleOrDefault(m => m.ID == 3)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 2)!);
			context.Movies.SingleOrDefault(m => m.ID == 3)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 3)!);
			context.Orders.SingleOrDefault(o => o.ID == 1)!.Customer = context.Customers.SingleOrDefault(c => c.ID == 1); // Applying order relations.
			context.Orders.SingleOrDefault(o => o.ID == 1)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 2)!);
			context.Orders.SingleOrDefault(o => o.ID == 1)!.Cost = context.Movies.SingleOrDefault(m => m.ID == 2)!.Price;
			context.Orders.SingleOrDefault(o => o.ID == 2)!.Customer = context.Customers.SingleOrDefault(c => c.ID == 2);
			context.Orders.SingleOrDefault(o => o.ID == 2)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 1)!);
			context.Orders.SingleOrDefault(o => o.ID == 2)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 2)!);
			context.Orders.SingleOrDefault(o => o.ID == 2)!.Cost = context.Movies.SingleOrDefault(m => m.ID == 1)!.Price + context.Movies.SingleOrDefault(m => m.ID == 2)!.Price;
			context.Orders.SingleOrDefault(o => o.ID == 3)!.Customer = context.Customers.SingleOrDefault(c => c.ID == 3);
			context.Orders.SingleOrDefault(o => o.ID == 3)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 3)!);
			context.Orders.SingleOrDefault(o => o.ID == 3)!.Cost = context.Movies.SingleOrDefault(m => m.ID == 3)!.Price;
			context.SaveChanges();
		}
	}
}