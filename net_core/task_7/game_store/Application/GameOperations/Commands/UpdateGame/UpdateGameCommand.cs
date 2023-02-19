using game_store.DBOperations;
using game_store.Entities;
namespace game_store.Application.GameOperations.Commands.UpdateGame {
	public class UpdateGameCommand {
		public int GameID { get; set; }
		public UpdateGameModel Model { get; set; } = null!;
		private readonly IGameStoreDbContext context;
		public UpdateGameCommand(IGameStoreDbContext context) {
			this.context = context;
		}
		public void Handle() {
			Game? game = context.Games.SingleOrDefault(g => g.ID == GameID);
			if (game == null) throw new InvalidOperationException("Game could not be found.");
			game.Name = Model.Name != default ? Model.Name : game.Name;
			game.Year = Model.Year != default ? Model.Year : game.Year;
			game.Price = Model.Price != default ? Model.Price : game.Price;
			context.GameDevelopers.RemoveRange(context.GameDevelopers.Where(gd => gd.GameID == GameID));
			foreach (int developer_ID in Model.DeveloperIDs) {
				if (!context.Developers.Any(d => d.ID == developer_ID)) throw new InvalidOperationException("Developer could not be found.");
				context.GameDevelopers.Add(new GameDeveloper { GameID = GameID, DeveloperID = developer_ID });
			}
			context.GamePublishers.RemoveRange(context.GamePublishers.Where(gp => gp.GameID == GameID));
			foreach (int publisher_ID in Model.PublisherIDs) {
				if (!context.Publishers.Any(p => p.ID == publisher_ID)) throw new InvalidOperationException("Publisher could not be found.");
				context.GamePublishers.Add(new GamePublisher { GameID = GameID, PublisherID = publisher_ID });
			}
			context.SaveChanges();
		}
		public class UpdateGameModel {
			public string? Name { get; set; }
			public int Year { get; set; }
			public double Price { get; set; }
			public List<int> DeveloperIDs { get; set; } = null!;
			public List<int> PublisherIDs { get; set; } = null!;
		}
	}
}