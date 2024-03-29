﻿using Microsoft.EntityFrameworkCore;
using movie_store.Entities;
namespace movie_store.DBOperations {
	public class MovieStoreDbContext : DbContext, IMovieStoreDbContext {
		public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options) { }
		public DbSet<Actor> Actors { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<CustomerGenre> CustomerGenres { get; set; }
		public DbSet<Director> Directors { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<MovieActor> MovieActors { get; set; }
		public DbSet<MovieDirector> MovieDirectors { get; set; }
		public DbSet<MovieGenre> MovieGenres { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderMovie> OrderMovies { get; set; }
		public override int SaveChanges() {
			return base.SaveChanges();
		}
	}
}