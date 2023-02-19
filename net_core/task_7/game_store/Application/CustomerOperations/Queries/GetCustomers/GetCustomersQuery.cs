using AutoMapper;
using game_store.DBOperations;
using game_store.Entities;
namespace game_store.Application.CustomerOperations.Queries.GetCustomers {
	public class GetCustomersQuery {
		private readonly IGameStoreDbContext context;
		private readonly IMapper mapper;
		public GetCustomersQuery(IGameStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public List<GetCustomersViewModel> Handle() {
			List<Customer>? list_customer = context.Customers.OrderBy(c => c.ID).ToList();
			List<GetCustomersViewModel> list_view_model = mapper.Map<List<GetCustomersViewModel>>(list_customer);
			foreach (int customer_ID in list_customer.Select(lc => lc.ID)) {
				List<string> list_game = new List<string>();
				foreach (int order_ID in context.Orders.Where(o => o.CustomerID == customer_ID).Select(o => o.ID)) foreach (int game_ID in context.OrderGames.Where(og => og.OrderID == order_ID).Select(og => og.GameID)) list_game.Add(context.Games.SingleOrDefault(g => g.ID == game_ID)!.Name!);
				list_view_model.SingleOrDefault(lvm => lvm.ID == customer_ID)!.Games = string.Join(", ", list_game);
			}
			return list_view_model;
		}
		public class GetCustomersViewModel {
			public int ID { get; set; }
			public string? Email { get; set; }
			public string? Password { get; set; }
			public string? Games { get; set; }
		}
	}
}