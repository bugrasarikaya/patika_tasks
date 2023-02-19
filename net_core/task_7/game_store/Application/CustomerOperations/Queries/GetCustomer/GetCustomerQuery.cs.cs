using AutoMapper;
using game_store.DBOperations;
using game_store.Entities;
namespace game_store.Application.CustomerOperations.Queries.GetCustomer {
	public class GetCustomerQuery {
		private readonly IGameStoreDbContext context;
		private readonly IMapper mapper;
		public int CustomerID { get; set; }
		public GetCustomerQuery(IGameStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public GetCustomerViewModel Handle() {
			Customer? customer = context.Customers.Where(c => c.ID == CustomerID).SingleOrDefault();
			if (customer is null) throw new InvalidOperationException("Customer could not be found.");
			GetCustomerViewModel view_model = mapper.Map<GetCustomerViewModel>(customer);
			List<string> list_game = new List<string>();
			foreach (int order_ID in context.Orders.Where(o => o.CustomerID == CustomerID).Select(o => o.ID)) foreach (int game_ID in context.OrderGames.Where(og => og.OrderID == order_ID).Select(og => og.GameID)) list_game.Add(context.Games.SingleOrDefault(g => g.ID == game_ID)!.Name!);
			view_model.Games = string.Join(", ", list_game);
			return view_model;
		}
		public class GetCustomerViewModel {
			public int ID { get; set; }
			public string? Email { get; set; }
			public string? Password { get; set; }
			public string? Games { get; set; }
		}
	}
}