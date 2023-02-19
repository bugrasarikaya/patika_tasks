using game_store.DBOperations;
using game_store.Entities;
namespace game_store.Application.GameOperations.Commands.DeleteGame {
	public class DeleteGameCommand {
		private readonly IGameStoreDbContext context;
		public int GameID { get; set; }
		public DeleteGameCommand(IGameStoreDbContext context) {
			this.context = context;
		}
		public void Handle() {
			Game? game = context.Games.SingleOrDefault(g => g.ID == GameID);
			if (game == null) throw new InvalidOperationException("Game could not be found.");
			context.GameDevelopers.RemoveRange(context.GameDevelopers.Where(gd => gd.GameID == GameID));
			context.GamePublishers.RemoveRange(context.GamePublishers.Where(gp => gp.GameID == GameID));
			context.Games.Remove(game);
			context.SaveChanges();
		}
	}
}