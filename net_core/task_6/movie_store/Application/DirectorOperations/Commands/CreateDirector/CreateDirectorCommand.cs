using AutoMapper;
using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.DirectorOperations.Commands.CreateDirector {
	public class CreateDirectorCommand {
		public CreateDirectorModel Model { get; set; } = null!;
		private readonly IMovieStoreDbContext context;
		private readonly IMapper mapper;
		public CreateDirectorCommand(IMovieStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public void Handle() {
			Director? Director = context.Directors.SingleOrDefault(d => d.Name == Model.Name && d.Surname == Model.Surname);
			if (Director != null) throw new InvalidOperationException("Director already exists.");
			Director = mapper.Map<Director>(Model);
			context.Directors.Add(Director);
			context.SaveChanges();
		}
		public class CreateDirectorModel {
			public string? Name { get; set; }
			public string? Surname { get; set; }
		}
	}
}