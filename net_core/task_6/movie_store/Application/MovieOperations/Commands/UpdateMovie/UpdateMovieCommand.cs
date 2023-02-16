using Microsoft.EntityFrameworkCore;
using movie_store.DBOperations;
using movie_store.Entities;
using System.Collections.Generic;
namespace movie_store.Application.MovieOperations.Commands.UpdateMovie {
	public class UpdateMovieCommand {
		public int MovieID { get; set; }
		public UpdateMovieModel Model { get; set; } = null!;
		private readonly IMovieStoreDbContext context;
		public UpdateMovieCommand(IMovieStoreDbContext context) {
			this.context = context;
		}
		public void Handle() {
			Movie? movie = context.Movies.SingleOrDefault(m => m.ID == MovieID);
			if (movie == null) throw new InvalidOperationException("Movie could not be found.");
			movie.Name = Model.Name != default ? Model.Name : movie.Name;
			movie.Year = Model.Year != default ? Model.Year : movie.Year;
			Director? director = context.Directors.SingleOrDefault(d => d.ID == Model.DirectorID);
			if (director == null) throw new InvalidOperationException("Director could not be found");
			movie.Director = director;
			foreach (Actor movie_actor in movie.Actors.ToList()) {
				bool existing_actor = false;
				foreach (int actor_ID in Model.ActorIDs) {
					Actor? actor = context.Actors.SingleOrDefault(a => a.ID == actor_ID);
					if (actor == null) throw new InvalidOperationException("Actor could not be found.");
					if (!actor.Movies.Any(m => m.ID == movie.ID)) actor.Movies.Add(movie);
					if (!movie.Actors.Any(a => a.ID == actor_ID)) movie.Actors.Add(actor);
					if (movie_actor.ID == actor_ID) existing_actor |= true;
				}
				if (!existing_actor) {
					movie_actor.Movies.Remove(movie);
					movie.Actors.Remove(movie_actor);
				}
			}
			movie.Genres.Clear();
			foreach (int genre_ID in Model.GenreIDs) {
				Genre? genre = context.Genres.SingleOrDefault(g => g.ID == genre_ID);
				if (genre == null) throw new InvalidOperationException("Genre could not be found.");
				movie.Genres.Add(genre);
			}
			movie.Price = Model.Price != default ? Model.Price : movie.Price;
			context.SaveChanges();
		}
		public class UpdateMovieModel {
			public string? Name { get; set; }
			public int Year { get; set; }
			public int DirectorID { get; set; }
			public List<int> ActorIDs { get; set; } = null!;
			public List<int> GenreIDs { get; set; } = null!;
			public double Price { get; set; }
		}
	}
}