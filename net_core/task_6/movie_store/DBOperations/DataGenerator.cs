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
					new Order { ID = 1, CustomerID = 1, Customer = "Ash Rivers", CustomerEmail = "ashrivers@schrecknet.vtm", Cost = 4.99, DateTime = new DateTime(2020, 01, 01) },
					new Order { ID = 2, CustomerID = 2, Customer = "Heather Poe", CustomerEmail = "heatherpoe@schrecknet.vtm", Cost = 4.99 + 8.99, DateTime = new DateTime(2020, 01, 02) },
					new Order { ID = 3, CustomerID = 3, Customer = "Isaac Abrams", CustomerEmail = "isaacabrams@schrecknet.vtm", Cost = 4.99, DateTime = new DateTime(2020, 01, 03) },
					new Order { ID = 4, CustomerID = 4, Customer = "Jack Smiling", CustomerEmail = "jacksmiling@schrecknet.vtm", Cost = 9.99, DateTime = new DateTime(2020, 01, 04) },
					new Order { ID = 5, CustomerID = 5, Customer = "Jeanette Voerman", CustomerEmail = "jeanettevoerman@schrecknet.vtm", Cost = 4.99 + 4.99, DateTime = new DateTime(2020, 01, 05) }
				);
				context.CustomerGenres.AddRange(
					new CustomerGenre { ID = 1, CustomerID = 1, GenreID = 4 },
					new CustomerGenre { ID = 2, CustomerID = 1, GenreID = 7 },
					new CustomerGenre { ID = 3, CustomerID = 2, GenreID = 5 },
					new CustomerGenre { ID = 4, CustomerID = 2, GenreID = 6 },
					new CustomerGenre { ID = 5, CustomerID = 3, GenreID = 4 },
					new CustomerGenre { ID = 6, CustomerID = 3, GenreID = 5 },
					new CustomerGenre { ID = 7, CustomerID = 3, GenreID = 7 },
					new CustomerGenre { ID = 8, CustomerID = 4, GenreID = 1 },
					new CustomerGenre { ID = 9, CustomerID = 5, GenreID = 3 },
					new CustomerGenre { ID = 10, CustomerID = 5, GenreID = 7 }
				);
				context.MovieActors.AddRange(
					new MovieActor { ID = 1, MovieID = 1, ActorID = 1 },
					new MovieActor { ID = 2, MovieID = 1, ActorID = 2 },
					new MovieActor { ID = 3, MovieID = 1, ActorID = 3 },
					new MovieActor { ID = 4, MovieID = 2, ActorID = 1 },
					new MovieActor { ID = 5, MovieID = 2, ActorID = 4 },
					new MovieActor { ID = 6, MovieID = 2, ActorID = 5 },
					new MovieActor { ID = 7, MovieID = 3, ActorID = 2 },
					new MovieActor { ID = 8, MovieID = 3, ActorID = 8 },
					new MovieActor { ID = 9, MovieID = 3, ActorID = 9 },
					new MovieActor { ID = 10, MovieID = 4, ActorID = 5 },
					new MovieActor { ID = 11, MovieID = 4, ActorID = 6 },
					new MovieActor { ID = 12, MovieID = 4, ActorID = 7 },
					new MovieActor { ID = 13, MovieID = 4, ActorID = 8 },
					new MovieActor { ID = 14, MovieID = 5, ActorID = 9 },
					new MovieActor { ID = 15, MovieID = 5, ActorID = 10 },
					new MovieActor { ID = 16, MovieID = 6, ActorID = 4 },
					new MovieActor { ID = 17, MovieID = 6, ActorID = 7 },
					new MovieActor { ID = 18, MovieID = 6, ActorID = 3 },
					new MovieActor { ID = 19, MovieID = 6, ActorID = 10 }
				);
				context.MovieDirectors.AddRange(
					new MovieDirector { ID = 1, MovieID = 1, DirectorID = 1 },
					new MovieDirector { ID = 2, MovieID = 2, DirectorID = 2 },
					new MovieDirector { ID = 3, MovieID = 3, DirectorID = 3 },
					new MovieDirector { ID = 4, MovieID = 4, DirectorID = 4 },
					new MovieDirector { ID = 5, MovieID = 5, DirectorID = 5 }
				);
				context.MovieGenres.AddRange(
					new MovieGenre { ID = 1, MovieID = 1, GenreID = 1 },
					new MovieGenre { ID = 2, MovieID = 1, GenreID = 3 },
					new MovieGenre { ID = 3, MovieID = 1, GenreID = 5 },
					new MovieGenre { ID = 4, MovieID = 2, GenreID = 1 },
					new MovieGenre { ID = 5, MovieID = 2, GenreID = 2 },
					new MovieGenre { ID = 6, MovieID = 2, GenreID = 3 },
					new MovieGenre { ID = 7, MovieID = 3, GenreID = 4 },
					new MovieGenre { ID = 8, MovieID = 3, GenreID = 5 },
					new MovieGenre { ID = 9, MovieID = 3, GenreID = 7 },
					new MovieGenre { ID = 10, MovieID = 4, GenreID = 1 },
					new MovieGenre { ID = 11, MovieID = 4, GenreID = 2 },
					new MovieGenre { ID = 12, MovieID = 5, GenreID = 1 },
					new MovieGenre { ID = 13, MovieID = 5, GenreID = 2 },
					new MovieGenre { ID = 14, MovieID = 5, GenreID = 3 },
					new MovieGenre { ID = 15, MovieID = 6, GenreID = 1 },
					new MovieGenre { ID = 16, MovieID = 6, GenreID = 2 },
					new MovieGenre { ID = 17, MovieID = 6, GenreID = 6 },
					new MovieGenre { ID = 18, MovieID = 7, GenreID = 2 },
					new MovieGenre { ID = 19, MovieID = 7, GenreID = 3 }
				);
				context.OrderMovies.AddRange(
					new OrderMovie { ID = 1, OrderID = 1, MovieID = 3 },
					new OrderMovie { ID = 2, OrderID = 1, MovieID = 3 },
					new OrderMovie { ID = 3, OrderID = 2, MovieID = 3 },
					new OrderMovie { ID = 4, OrderID = 2, MovieID = 6 },
					new OrderMovie { ID = 5, OrderID = 3, MovieID = 3 },
					new OrderMovie { ID = 6, OrderID = 4, MovieID = 2 },
					new OrderMovie { ID = 7, OrderID = 5, MovieID = 3 },
					new OrderMovie { ID = 8, OrderID = 5, MovieID = 7 }
				);
				context.SaveChanges();
			}
		}
	}
}