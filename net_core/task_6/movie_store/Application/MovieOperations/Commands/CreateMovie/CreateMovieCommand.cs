using AutoMapper;
using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.MovieOperations.Commands.CreateMovie {
	public class CreateMovieCommand {
		public CreateMovieModel Model { get; set; } = null!;
		private readonly IMovieStoreDbContext context;
		private readonly IMapper mapper;
		public CreateMovieCommand(IMovieStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public void Handle() {
			Movie? movie = context.Movies.SingleOrDefault(m => m.Name == Model.Name);
			if (movie != null) throw new InvalidOperationException("Movie already exists.");
			movie = mapper.Map<Movie>(Model);
			context.Movies.Add(movie);
			context.SaveChanges();
		}
		public class CreateMovieModel {
			public string? Name { get; set; }
			public int Year { get; set; }
			public double Price { get; set; }
		}
	}
}