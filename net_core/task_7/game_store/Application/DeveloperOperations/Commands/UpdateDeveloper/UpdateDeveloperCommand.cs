using game_store.DBOperations;
using game_store.Entities;
namespace game_store.Application.DeveloperOperations.Commands.UpdateDeveloper {
	public class UpdateDeveloperCommand {
		public int DeveloperID { get; set; }
		public UpdateDeveloperModel Model { get; set; } = null!;
		private readonly IGameStoreDbContext context;
		public UpdateDeveloperCommand(IGameStoreDbContext context) {
			this.context = context;
		}
		public void Handle() {
			Developer? developer = context.Developers.SingleOrDefault(d => d.ID == DeveloperID);
			if (developer == null) throw new InvalidOperationException("Developer could not be found.");
			developer.Name = Model.Name != default ? Model.Name : developer.Name;
			developer.Year = Model.Year != default ? Model.Year : developer.Year;
			if (context.Developers.Any(d => d.Name == developer.Name)) throw new InvalidOperationException("Developer already exists.");
			context.SaveChanges();
		}
		public class UpdateDeveloperModel {
			public string? Name { get; set; }
			public int Year { get; set; }
		}
	}
}