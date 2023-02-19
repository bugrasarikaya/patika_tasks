using AutoMapper;
using game_store.DBOperations;
using game_store.Entities;
namespace game_store.Application.OrderOperations.Queries.GetOrders {
	public class GetOrdersQuery {
		private readonly IGameStoreDbContext context;
		private readonly IMapper mapper;
		public GetOrdersQuery(IGameStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public List<GetOrdersViewModel> Handle() {
			List<Order>? list_order = context.Orders.OrderBy(o => o.ID).ToList();
			List<GetOrdersViewModel> list_view_model = mapper.Map<List<GetOrdersViewModel>>(list_order);
			foreach (int order_ID in list_order.Select(lo => lo.ID)) {
				List<string> list_game = new List<string>();
				foreach (int game_ID in context.OrderGames.Where(og => og.OrderID == order_ID).Select(og => og.GameID)) list_game.Add(context.Games.SingleOrDefault(g => g.ID == game_ID)!.Name!);
				list_view_model.SingleOrDefault(lvm => lvm.ID == order_ID)!.Games = string.Join(", ", list_game);
			}
			return list_view_model;
		}
		public class GetOrdersViewModel {
			public int ID { get; set; }
			public int CustomerID { get; set; }
			public string? CustomerEmail { get; set; }
			public string? Games { get; set; }
			public double Cost { get; set; }
			public DateTime DateTime { get; set; }
		}
	}
}