using AutoMapper;
using game_store.DBOperations;
using game_store.Entities;
namespace game_store.Application.PublisherOperations.Queries.GetPublishers {
	public class GetPublishersQuery {
		private readonly IGameStoreDbContext context;
		private readonly IMapper mapper;
		public GetPublishersQuery(IGameStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public List<GetPublishersViewModel> Handle() {
			List<Publisher>? list_publisher = context.Publishers.OrderBy(p => p.ID).ToList();
			List<GetPublishersViewModel> list_view_model = mapper.Map<List<GetPublishersViewModel>>(list_publisher);
			foreach (int publisher_ID in list_publisher.Select(lp => lp.ID)) {
				List<string> list_game = new List<string>();
				foreach (int game_ID in context.GamePublishers.Where(gp => gp.PublisherID == publisher_ID).Select(gp => gp.GameID)) list_game.Add(context.Games.SingleOrDefault(g => g.ID == game_ID)!.Name!);
				list_view_model.SingleOrDefault(lvm => lvm.ID == publisher_ID)!.Games = string.Join(", ", list_game);
			}
			return list_view_model;
		}
		public class GetPublishersViewModel {
			public int ID { get; set; }
			public string? Name { get; set; }
			public int Year { get; set; }
			public string? Games { get; set; }
		}
	}
}