using game_store.DBOperations;
using game_store.Entities;
namespace game_store.Application.DeveloperOperations.Commands.DeleteDeveloper {
	public class DeleteDeveloperCommand {
		private readonly IGameStoreDbContext context;
		public int DeveloperID { get; set; }
		public DeleteDeveloperCommand(IGameStoreDbContext context) {
			this.context = context;
		}
		public void Handle() {
			Developer? developer = context.Developers.SingleOrDefault(d => d.ID == DeveloperID);
			if (developer == null) throw new InvalidOperationException("Developer could not be found.");
			if (context.GameDevelopers.Any(gd => gd.DeveloperID == DeveloperID)) throw new InvalidOperationException("Developer exists in a game.");
			context.Developers.Remove(developer);
			context.SaveChanges();
		}
	}
}