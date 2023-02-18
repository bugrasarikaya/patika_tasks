using AutoMapper;
using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.MovieOperations.Queries.GetMovies {
	public class GetMoviesQuery {
		private readonly IMovieStoreDbContext context;
		private readonly IMapper mapper;
		public GetMoviesQuery(IMovieStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public List<GetMoviesViewModel> Handle() {
			List<Movie>? list_movie = context.Movies.OrderBy(m => m.ID).ToList();
			List<GetMoviesViewModel> list_view_model = mapper.Map<List<GetMoviesViewModel>>(list_movie);
			foreach (int movie_ID in list_movie.Select(lm => lm.ID)) {
				List<string> list_actor = new List<string>();
				foreach (int actor_ID in context.MovieActors.Where(ma => ma.MovieID == movie_ID).Select(ma => ma.ActorID)) list_actor.Add(string.Format("{0} {1}", context.Actors.SingleOrDefault(a => a.ID == actor_ID)!.Name!, context.Actors.SingleOrDefault(a => a.ID == actor_ID)!.Surname!));
				list_view_model.SingleOrDefault(lvm => lvm.ID == movie_ID)!.Actors = string.Join(", ", list_actor);
				List<string> list_director = new List<string>();
				foreach (int director_ID in context.MovieDirectors.Where(md => md.MovieID == movie_ID).Select(md => md.DirectorID)) list_director.Add(string.Format("{0} {1}", context.Directors.SingleOrDefault(d => d.ID == director_ID)!.Name!, context.Directors.SingleOrDefault(d => d.ID == director_ID)!.Surname!));
				list_view_model.SingleOrDefault(lvm => lvm.ID == movie_ID)!.Director = string.Join(", ", list_director);
				List<string> list_genre = new List<string>();
				foreach (int genre_ID in context.MovieGenres.Where(mg => mg.MovieID == movie_ID).Select(mg => mg.GenreID)) list_genre.Add(context.Genres.SingleOrDefault(g => g.ID == genre_ID)!.Name!);
				list_view_model.SingleOrDefault(lvm => lvm.ID == movie_ID)!.Genres = string.Join(", ", list_genre);
			}
			return list_view_model;
		}
		public class GetMoviesViewModel {
			public int ID { get; set; }
			public string? Name { get; set; }
			public int Year { get; set; }
			public double Price { get; set; }
			public string? Actors { get; set; }
			public string? Director { get; set; }
			public string? Genres { get; set; }
		}
	}
}