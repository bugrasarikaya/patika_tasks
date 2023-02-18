using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.DirectorOperations.Commands.UpdateDirector {
	public class UpdateDirectorCommand {
		public int DirectorID { get; set; }
		public UpdateDirectorModel Model { get; set; } = null!;
		private readonly IMovieStoreDbContext context;
		public UpdateDirectorCommand(IMovieStoreDbContext context) {
			this.context = context;
		}
		public void Handle() {
			Director? director = context.Directors.SingleOrDefault(m => m.ID == DirectorID);
			if (director == null) throw new InvalidOperationException("Director could not be found.");
			director.Name = Model.Name != default ? Model.Name : director.Name;
			director.Surname = Model.Surname != default ? Model.Surname : director.Surname;
			if (context.Directors.Any(d => d.Name == director.Name && d.Surname == director.Surname)) throw new InvalidOperationException("Director already exists.");
			context.SaveChanges();
		}
		public class UpdateDirectorModel {
			public string? Name { get; set; }
			public string? Surname { get; set; }
		}
	}
}