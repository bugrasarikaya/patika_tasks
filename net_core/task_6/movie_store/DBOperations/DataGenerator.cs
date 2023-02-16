using Microsoft.EntityFrameworkCore;
using movie_store.Entities;
namespace movie_store.DBOperations {
	public class DataGenerator {
		public static void Initialize(IServiceProvider serviceProvider) {
			using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>())) {
				context.Actors.AddRange(
					new Actor { ID = 1, Name = "Kate", Surname = "Beckinsale" },
					new Actor { ID = 2, Name = "Scott", Surname = "Speedman" },
					new Actor { ID = 3, Name = "Michael", Surname = "Sheen" },
					new Actor { ID = 4, Name = "Hugh", Surname = "Jackman" },
					new Actor { ID = 5, Name = "David", Surname = "Wenham" },
					new Actor { ID = 6, Name = "Viggo", Surname = "Mortensen" },
					new Actor { ID = 7, Name = "Ian", Surname = "McKellen" },
					new Actor { ID = 8, Name = "Liv", Surname = "Tyler" },
					new Actor { ID = 9, Name = "Gemma", Surname = "Ward" },
					new Actor { ID = 10, Name = "Johnny", Surname = "Depp" }
				);
				context.Customers.AddRange(
					new Customer { ID = 1, Name = "Ash", Surname = "Rivers", Email = "ashrivers@schrecknet.vtm", Password = "12345678" },
					new Customer { ID = 2, Name = "Heather", Surname = "Poe", Email = "heatherpoe@schrecknet.vtm", Password = "12345678" },
					new Customer { ID = 3, Name = "Isaac", Surname = "Abrams", Email = "isaacabrams@schrecknet.vtm", Password = "12345678" },
					new Customer { ID = 4, Name = "Jack", Surname = "Smiling", Email = "jacksmiling@schrecknet.vtm", Password = "12345678" },
					new Customer { ID = 5, Name = "Jeanette", Surname = "Voerman", Email = "jeanettevoerman@schrecknet.vtm", Password = "12345678" }
				);
				context.Directors.AddRange(
					new Director { ID = 1, Name = "Len", Surname = "Wiseman" },
					new Director { ID = 2, Name = "Stephen", Surname = "Sommers" },
					new Director { ID = 3, Name = "Bryan", Surname = "Bertino" },
					new Director { ID = 4, Name = "Peter", Surname = "Jackson" },
					new Director { ID = 5, Name = "Rob", Surname = "Marshall" },
					new Director { ID = 6, Name = "Bryan", Surname = "Singer" },
					new Director { ID = 7, Name = "Tim", Surname = "Burton" }
				);
				context.Genres.AddRange(
					new Genre { ID = 1, Name = "Action" },
					new Genre { ID = 2, Name = "Adventure" },
					new Genre { ID = 3, Name = "Fantasy" },
					new Genre { ID = 4, Name = "Horror" },
					new Genre { ID = 5, Name = "Mystery" },
					new Genre { ID = 6, Name = "Sci-Fi" },
					new Genre { ID = 7, Name = "Thriller" }
				);
				context.Movies.AddRange(
					new Movie { ID = 1, Name = "Underworld", Year = 2003, Price = 12.99 },
					new Movie { ID = 2, Name = "Van Helsing", Year = 2004, Price = 9.99 },
					new Movie { ID = 3, Name = "The Strangers", Year = 2008, Price = 4.99 },
					new Movie { ID = 4, Name = "The Lord of the Rings: The Return of the King", Year = 2003, Price = 19.99 },
					new Movie { ID = 5, Name = "Pirates of the Caribbean: On Stranger Tides", Year = 2011, Price = 14.99 },
					new Movie { ID = 6, Name = "X-Men", Year = 2000, Price = 8.99 },
					new Movie { ID = 7, Name = "Alice in Wonderland", Year = 2010, Price = 4.99 }
				);
				context.Orders.AddRange(
					new Order { ID = 1, DateTime = new DateTime(2020, 01, 01) },
					new Order { ID = 2, DateTime = new DateTime(2020, 01, 02) },
					new Order { ID = 3, DateTime = new DateTime(2020, 01, 03) },
					new Order { ID = 4, DateTime = new DateTime(2020, 01, 04) },
					new Order { ID = 5, DateTime = new DateTime(2020, 01, 05) }
				);
				context.SaveChanges();
				context.Actors.SingleOrDefault(a => a.ID == 1)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 1)!); // Applying actor relations.
				context.Actors.SingleOrDefault(a => a.ID == 1)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 2)!); 
				context.Actors.SingleOrDefault(a => a.ID == 2)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 1)!);
				context.Actors.SingleOrDefault(a => a.ID == 2)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 3)!);
				context.Actors.SingleOrDefault(a => a.ID == 3)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 1)!);
				context.Actors.SingleOrDefault(a => a.ID == 3)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 7)!);
				context.Actors.SingleOrDefault(a => a.ID == 4)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 2)!);
				context.Actors.SingleOrDefault(a => a.ID == 4)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 6)!);
				context.Actors.SingleOrDefault(a => a.ID == 5)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 2)!);
				context.Actors.SingleOrDefault(a => a.ID == 5)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 4)!);
				context.Actors.SingleOrDefault(a => a.ID == 6)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 4)!);
				context.Actors.SingleOrDefault(a => a.ID == 7)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 4)!);
				context.Actors.SingleOrDefault(a => a.ID == 7)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 6)!);
				context.Actors.SingleOrDefault(a => a.ID == 8)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 3)!);
				context.Actors.SingleOrDefault(a => a.ID == 8)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 4)!);
				context.Actors.SingleOrDefault(a => a.ID == 9)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 3)!);
				context.Actors.SingleOrDefault(a => a.ID == 9)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 5)!);
				context.Actors.SingleOrDefault(a => a.ID == 10)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 5)!);
				context.Actors.SingleOrDefault(a => a.ID == 10)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 7)!);
				context.Customers.SingleOrDefault(c => c.ID == 1)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 3)!); // Applying customer relations.
				context.Customers.SingleOrDefault(c => c.ID == 1)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 4)!);
				context.Customers.SingleOrDefault(c => c.ID == 1)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 7)!);
				context.Customers.SingleOrDefault(c => c.ID == 2)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 3)!);
				context.Customers.SingleOrDefault(c => c.ID == 2)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 6)!);
				context.Customers.SingleOrDefault(c => c.ID == 2)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 5)!);
				context.Customers.SingleOrDefault(c => c.ID == 2)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 6)!);
				context.Customers.SingleOrDefault(c => c.ID == 3)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 3)!);
				context.Customers.SingleOrDefault(c => c.ID == 3)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 4)!);
				context.Customers.SingleOrDefault(c => c.ID == 3)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 5)!);
				context.Customers.SingleOrDefault(c => c.ID == 3)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 7)!);
				context.Customers.SingleOrDefault(c => c.ID == 4)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 2)!);
				context.Customers.SingleOrDefault(c => c.ID == 4)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 1)!);
				context.Customers.SingleOrDefault(c => c.ID == 5)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 3)!);
				context.Customers.SingleOrDefault(c => c.ID == 5)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 7)!);
				context.Customers.SingleOrDefault(c => c.ID == 5)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 3)!);
				context.Customers.SingleOrDefault(c => c.ID == 5)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 7)!);
				context.Directors.SingleOrDefault(d => d.ID == 1)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 1)!); // Applying director relations.
				context.Directors.SingleOrDefault(d => d.ID == 2)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 2)!);
				context.Directors.SingleOrDefault(d => d.ID == 3)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 3)!);
				context.Directors.SingleOrDefault(d => d.ID == 4)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 4)!);
				context.Directors.SingleOrDefault(d => d.ID == 5)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 5)!);
				context.Directors.SingleOrDefault(d => d.ID == 6)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 6)!);
				context.Directors.SingleOrDefault(d => d.ID == 7)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 7)!);
				context.Movies.SingleOrDefault(m => m.ID == 1)!.Actors.Add(context.Actors.SingleOrDefault(a => a.ID == 1)!); // Applying movie relations.
				context.Movies.SingleOrDefault(m => m.ID == 1)!.Actors.Add(context.Actors.SingleOrDefault(a => a.ID == 2)!);
				context.Movies.SingleOrDefault(m => m.ID == 1)!.Actors.Add(context.Actors.SingleOrDefault(a => a.ID == 3)!);
				context.Movies.SingleOrDefault(m => m.ID == 1)!.Director = context.Directors.SingleOrDefault(a => a.ID == 1)!;
				context.Movies.SingleOrDefault(m => m.ID == 1)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 1)!);
				context.Movies.SingleOrDefault(m => m.ID == 1)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 3)!);
				context.Movies.SingleOrDefault(m => m.ID == 1)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 7)!);
				context.Movies.SingleOrDefault(m => m.ID == 2)!.Actors.Add(context.Actors.SingleOrDefault(a => a.ID == 1)!);
				context.Movies.SingleOrDefault(m => m.ID == 2)!.Actors.Add(context.Actors.SingleOrDefault(a => a.ID == 4)!);
				context.Movies.SingleOrDefault(m => m.ID == 2)!.Actors.Add(context.Actors.SingleOrDefault(a => a.ID == 5)!);
				context.Movies.SingleOrDefault(m => m.ID == 2)!.Director = context.Directors.SingleOrDefault(a => a.ID == 2)!;
				context.Movies.SingleOrDefault(m => m.ID == 2)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 1)!);
				context.Movies.SingleOrDefault(m => m.ID == 2)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 2)!);
				context.Movies.SingleOrDefault(m => m.ID == 2)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 3)!);
				context.Movies.SingleOrDefault(m => m.ID == 3)!.Actors.Add(context.Actors.SingleOrDefault(a => a.ID == 2)!);
				context.Movies.SingleOrDefault(m => m.ID == 3)!.Actors.Add(context.Actors.SingleOrDefault(a => a.ID == 8)!);
				context.Movies.SingleOrDefault(m => m.ID == 3)!.Actors.Add(context.Actors.SingleOrDefault(a => a.ID == 9)!);
				context.Movies.SingleOrDefault(m => m.ID == 3)!.Director = context.Directors.SingleOrDefault(a => a.ID == 3)!;
				context.Movies.SingleOrDefault(m => m.ID == 3)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 4)!);
				context.Movies.SingleOrDefault(m => m.ID == 3)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 5)!);
				context.Movies.SingleOrDefault(m => m.ID == 3)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 7)!);
				context.Movies.SingleOrDefault(m => m.ID == 4)!.Actors.Add(context.Actors.SingleOrDefault(a => a.ID == 5)!);
				context.Movies.SingleOrDefault(m => m.ID == 4)!.Actors.Add(context.Actors.SingleOrDefault(a => a.ID == 6)!);
				context.Movies.SingleOrDefault(m => m.ID == 4)!.Actors.Add(context.Actors.SingleOrDefault(a => a.ID == 7)!);
				context.Movies.SingleOrDefault(m => m.ID == 4)!.Actors.Add(context.Actors.SingleOrDefault(a => a.ID == 8)!);
				context.Movies.SingleOrDefault(m => m.ID == 4)!.Director = context.Directors.SingleOrDefault(a => a.ID == 4)!;
				context.Movies.SingleOrDefault(m => m.ID == 4)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 1)!);
				context.Movies.SingleOrDefault(m => m.ID == 4)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 2)!);
				context.Movies.SingleOrDefault(m => m.ID == 5)!.Actors.Add(context.Actors.SingleOrDefault(a => a.ID == 9)!);
				context.Movies.SingleOrDefault(m => m.ID == 5)!.Actors.Add(context.Actors.SingleOrDefault(a => a.ID == 10)!);
				context.Movies.SingleOrDefault(m => m.ID == 5)!.Director = context.Directors.SingleOrDefault(a => a.ID == 5)!;
				context.Movies.SingleOrDefault(m => m.ID == 5)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 1)!);
				context.Movies.SingleOrDefault(m => m.ID == 5)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 2)!);
				context.Movies.SingleOrDefault(m => m.ID == 5)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 3)!);
				context.Movies.SingleOrDefault(m => m.ID == 6)!.Actors.Add(context.Actors.SingleOrDefault(a => a.ID == 4)!);
				context.Movies.SingleOrDefault(m => m.ID == 6)!.Actors.Add(context.Actors.SingleOrDefault(a => a.ID == 7)!);
				context.Movies.SingleOrDefault(m => m.ID == 6)!.Director = context.Directors.SingleOrDefault(a => a.ID == 6)!;
				context.Movies.SingleOrDefault(m => m.ID == 6)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 1)!);
				context.Movies.SingleOrDefault(m => m.ID == 6)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 2)!);
				context.Movies.SingleOrDefault(m => m.ID == 6)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 6)!);
				context.Movies.SingleOrDefault(m => m.ID == 7)!.Actors.Add(context.Actors.SingleOrDefault(a => a.ID == 3)!);
				context.Movies.SingleOrDefault(m => m.ID == 7)!.Actors.Add(context.Actors.SingleOrDefault(a => a.ID == 10)!);
				context.Movies.SingleOrDefault(m => m.ID == 7)!.Director = context.Directors.SingleOrDefault(a => a.ID == 7)!;
				context.Movies.SingleOrDefault(m => m.ID == 7)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 2)!);
				context.Movies.SingleOrDefault(m => m.ID == 7)!.Genres.Add(context.Genres.SingleOrDefault(g => g.ID == 3)!);
				context.Orders.SingleOrDefault(o => o.ID == 1)!.Customer = context.Customers.SingleOrDefault(c => c.ID == 1); // Applying order relations.
				context.Orders.SingleOrDefault(o => o.ID == 1)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 3)!);
				context.Orders.SingleOrDefault(o => o.ID == 1)!.Cost = context.Movies.SingleOrDefault(m => m.ID == 3)!.Price;
				context.Orders.SingleOrDefault(o => o.ID == 2)!.Customer = context.Customers.SingleOrDefault(c => c.ID == 2);
				context.Orders.SingleOrDefault(o => o.ID == 2)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 3)!);
				context.Orders.SingleOrDefault(o => o.ID == 2)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 6)!);
				context.Orders.SingleOrDefault(o => o.ID == 2)!.Cost = context.Movies.SingleOrDefault(m => m.ID == 3)!.Price + context.Movies.SingleOrDefault(m => m.ID == 6)!.Price;
				context.Orders.SingleOrDefault(o => o.ID == 3)!.Customer = context.Customers.SingleOrDefault(c => c.ID == 3);
				context.Orders.SingleOrDefault(o => o.ID == 3)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 3)!);
				context.Orders.SingleOrDefault(o => o.ID == 3)!.Cost = context.Movies.SingleOrDefault(m => m.ID == 3)!.Price;
				context.Orders.SingleOrDefault(o => o.ID == 4)!.Customer = context.Customers.SingleOrDefault(c => c.ID == 4);
				context.Orders.SingleOrDefault(o => o.ID == 4)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 2)!);
				context.Orders.SingleOrDefault(o => o.ID == 4)!.Cost = context.Movies.SingleOrDefault(m => m.ID == 2)!.Price;
				context.Orders.SingleOrDefault(o => o.ID == 5)!.Customer = context.Customers.SingleOrDefault(c => c.ID == 5);
				context.Orders.SingleOrDefault(o => o.ID == 5)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 3)!);
				context.Orders.SingleOrDefault(o => o.ID == 5)!.Movies.Add(context.Movies.SingleOrDefault(m => m.ID == 7)!);
				context.Orders.SingleOrDefault(o => o.ID == 5)!.Cost = context.Movies.SingleOrDefault(m => m.ID == 3)!.Price + context.Movies.SingleOrDefault(m => m.ID == 7)!.Price;
				context.SaveChanges();
			}
		}
	}
}