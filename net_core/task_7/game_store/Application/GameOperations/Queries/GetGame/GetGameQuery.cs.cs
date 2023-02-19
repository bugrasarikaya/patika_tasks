using AutoMapper;
using game_store.DBOperations;
using game_store.Entities;
namespace game_store.Application.GameOperations.Queries.GetGame {
	public class GetGameQuery {
		private readonly IGameStoreDbContext context;
		private readonly IMapper mapper;
		public int GameID { get; set; }
		public GetGameQuery(IGameStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public GetGameViewModel Handle() {
			Game? game = context.Games.Where(g => g.ID == GameID).SingleOrDefault();
			if (game is null) throw new InvalidOperationException("Game could not be found.");
			GetGameViewModel view_model = mapper.Map<GetGameViewModel>(game);
			List<string> list_developer = new List<string>();
			foreach (int developer_ID in context.GameDevelopers.Where(gd => gd.GameID == GameID).Select(gd => gd.DeveloperID)) list_developer.Add(context.Developers.SingleOrDefault(d => d.ID == developer_ID)!.Name!);
			view_model.Developers = string.Join(", ", list_developer);
			List<string> list_publisher = new List<string>();
			foreach (int publisher_ID in context.GamePublishers.Where(gp => gp.GameID == GameID).Select(gp => gp.PublisherID)) list_publisher.Add(context.Publishers.SingleOrDefault(p => p.ID == publisher_ID)!.Name!);
			view_model.Publisher = string.Join(", ", list_publisher);
			return view_model;
		}
		public class GetGameViewModel {
			public int ID { get; set; }
			public string? Name { get; set; }
			public int Year { get; set; }
			public double Price { get; set; }
			public string? Developers { get; set; }
			public string? Publisher { get; set; }
		}
	}
}