using AutoMapper;
using game_store.DBOperations;
using game_store.Entities;
namespace game_store.Application.OrderOperations.Queries.GetOrder {
	public class GetOrderQuery {
		private readonly IGameStoreDbContext context;
		private readonly IMapper mapper;
		public int OrderID { get; set; }
		public GetOrderQuery(IGameStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public GetOrderViewModel Handle() {
			Order? order = context.Orders.Where(o => o.ID == OrderID).SingleOrDefault();
			if (order is null) throw new InvalidOperationException("Order could not be found.");
			GetOrderViewModel view_model = mapper.Map<GetOrderViewModel>(order);
			List<string> list_game = new List<string>();
			foreach (int game_ID in context.OrderGames.Where(og => og.OrderID == OrderID).Select(og => og.GameID)) list_game.Add(context.Games.SingleOrDefault(g => g.ID == game_ID)!.Name!);
			view_model.Games = string.Join(", ", list_game);
			return view_model;
		}
		public class GetOrderViewModel {
			public int ID { get; set; }
			public int CustomerID { get; set; }
			public string? CustomerEmail { get; set; }
			public string? Games { get; set; }
			public double Cost { get; set; }
			public DateTime DateTime { get; set; }
		}
	}
}