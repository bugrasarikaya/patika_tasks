using AutoMapper;
using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.MovieOperations.Queries.GetMovie {
	public class GetMovieQuery {
		private readonly IMovieStoreDbContext context;
		private readonly IMapper mapper;
		public int MovieID { get; set; }
		public GetMovieQuery(IMovieStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public GetMovieViewModel Handle() {
			Movie? movie = context.Movies.Where(m => m.ID == MovieID).SingleOrDefault();
			if (movie is null) throw new InvalidOperationException("Movie could not be found.");
			GetMovieViewModel view_model = mapper.Map<GetMovieViewModel>(movie);
			List<string> list_actor = new List<string>();
			foreach (int actor_ID in context.MovieActors.Where(ma => ma.MovieID == MovieID).Select(ma => ma.ActorID)) list_actor.Add(string.Format("{0} {1}", context.Actors.SingleOrDefault(a => a.ID == actor_ID)!.Name!, context.Actors.SingleOrDefault(a => a.ID == actor_ID)!.Surname!));
			view_model.Actors = string.Join(", ", list_actor);
			List<string> list_director = new List<string>();
			foreach (int director_ID in context.MovieDirectors.Where(md => md.MovieID == MovieID).Select(md => md.DirectorID)) list_director.Add(string.Format("{0} {1}", context.Directors.SingleOrDefault(d => d.ID == director_ID)!.Name!, context.Directors.SingleOrDefault(d => d.ID == director_ID)!.Surname!));
			view_model.Director = string.Join(", ", list_director);
			List<string> list_genre = new List<string>();
			foreach (int genre_ID in context.MovieGenres.Where(mg => mg.MovieID == MovieID).Select(mg => mg.GenreID)) list_genre.Add(context.Genres.SingleOrDefault(g => g.ID == genre_ID)!.Name!);
			view_model.Genres = string.Join(", ", list_genre);
			return view_model;
		}
		public class GetMovieViewModel {
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