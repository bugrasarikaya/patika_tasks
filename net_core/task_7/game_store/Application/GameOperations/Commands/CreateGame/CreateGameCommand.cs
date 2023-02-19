using AutoMapper;
using game_store.DBOperations;
using game_store.Entities;
namespace game_store.Application.GameOperations.Commands.CreateGame {
	public class CreateGameCommand {
		public CreateGameModel Model { get; set; } = null!;
		private readonly IGameStoreDbContext context;
		private readonly IMapper mapper;
		public CreateGameCommand(IGameStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public void Handle() {
			Game? game = context.Games.SingleOrDefault(g => g.Name == Model.Name);
			if (game != null) throw new InvalidOperationException("Game already exists.");
			game = mapper.Map<Game>(Model);
			context.Games.Add(game);
			context.SaveChanges();
		}
		public class CreateGameModel {
			public string? Name { get; set; }
			public int Year { get; set; }
			public double Price { get; set; }
		}
	}
}