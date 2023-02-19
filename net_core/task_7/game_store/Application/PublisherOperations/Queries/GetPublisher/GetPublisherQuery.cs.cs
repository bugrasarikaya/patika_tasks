using AutoMapper;
using game_store.DBOperations;
using game_store.Entities;
namespace game_store.Application.PublisherOperations.Queries.GetPublisher {
	public class GetPublisherQuery {
		private readonly IGameStoreDbContext context;
		private readonly IMapper mapper;
		public int PublisherID { get; set; }
		public GetPublisherQuery(IGameStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public GetPublisherViewModel Handle() {
			Publisher? publisher = context.Publishers.Where(p => p.ID == PublisherID).SingleOrDefault();
			if (publisher is null) throw new InvalidOperationException("Publisher could not be found.");
			GetPublisherViewModel view_model = mapper.Map<GetPublisherViewModel>(publisher);
			List<string> list_game = new List<string>();
			foreach (int game_ID in context.GamePublishers.Where(gp => gp.PublisherID == PublisherID).Select(gp => gp.GameID)) list_game.Add(context.Games.SingleOrDefault(g => g.ID == game_ID)!.Name!);
			view_model.Games = string.Join(", ", list_game);
			return view_model;
		}
		public class GetPublisherViewModel {
			public int ID { get; set; }
			public string? Name { get; set; }
			public int Year { get; set; }
			public string? Games { get; set; }
		}
	}
}