using AutoMapper;
using game_store.DBOperations;
using game_store.Entities;
namespace game_store.Application.GameOperations.Queries.GetGames {
	public class GetGamesQuery {
		private readonly IGameStoreDbContext context;
		private readonly IMapper mapper;
		public GetGamesQuery(IGameStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public List<GetGamesViewModel> Handle() {
			List<Game>? list_game = context.Games.OrderBy(g => g.ID).ToList();
			List<GetGamesViewModel> list_view_model = mapper.Map<List<GetGamesViewModel>>(list_game);
			foreach (int game_ID in list_game.Select(lg => lg.ID)) {
				List<string> list_developer = new List<string>();
				foreach (int developer_ID in context.GameDevelopers.Where(gd => gd.GameID == game_ID).Select(gd => gd.DeveloperID)) list_developer.Add(context.Developers.SingleOrDefault(d => d.ID == developer_ID)!.Name!);
				list_view_model.SingleOrDefault(lvm => lvm.ID == game_ID)!.Developers = string.Join(", ", list_developer);
				List<string> list_publisher = new List<string>();
				foreach (int publisher_ID in context.GamePublishers.Where(gp => gp.GameID == game_ID).Select(gp => gp.PublisherID)) list_publisher.Add(context.Publishers.SingleOrDefault(p => p.ID == publisher_ID)!.Name!);
				list_view_model.SingleOrDefault(lvm => lvm.ID == game_ID)!.Publishers = string.Join(", ", list_publisher);
			}
			return list_view_model;
		}
		public class GetGamesViewModel {
			public int ID { get; set; }
			public string? Name { get; set; }
			public int Year { get; set; }
			public double Price { get; set; }
			public string? Developers { get; set; }
			public string? Publishers { get; set; }
		}
	}
}