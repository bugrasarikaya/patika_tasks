using Microsoft.EntityFrameworkCore;
using movie_store.Entities;
namespace movie_store.DBOperations {
	public interface IMovieStoreDbContext {
		DbSet<Actor> Actors { get; set; }
		DbSet<Customer> Customers { get; set; }
		DbSet<CustomerGenre> CustomerGenres { get; set; }
		DbSet<Director> Directors { get; set; }
		DbSet<Genre> Genres { get; set; }
		DbSet<Movie> Movies { get; set; }
		DbSet<MovieActor> MovieActors { get; set; }
		DbSet<MovieDirector> MovieDirectors { get; set; }
		DbSet<MovieGenre> MovieGenres { get; set; }
		DbSet<Order> Orders { get; set; }
		DbSet<OrderMovie> OrderMovies { get; set; }
		int SaveChanges();
	}
}