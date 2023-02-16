using AutoMapper;
using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.GenreOperations.Commands.CreateGenre {
	public class CreateGenreCommand {
		public CreateGenreModel Model { get; set; } = null!;
		private readonly IMovieStoreDbContext context;
		private readonly IMapper mapper;
		public CreateGenreCommand(IMovieStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public void Handle() {
			Genre? genre = context.Genres.SingleOrDefault(g => g.Name == Model.Name);
			if (genre != null) throw new InvalidOperationException("Genre already exists.");
			genre = mapper.Map<Genre>(Model);
			context.Genres.Add(genre);
			context.SaveChanges();
		}
		public class CreateGenreModel {
			public string? Name { get; set; }
		}
	}
}