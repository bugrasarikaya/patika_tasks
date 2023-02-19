using game_store.DBOperations;
using game_store.Entities;
namespace game_store.Application.OrderOperations.Commands.CreateOrder {
	public class CreateOrderCommand {
		public CreateOrderModel Model { get; set; } = null!;
		public Order Order { get; set; } = null!;
		private readonly IGameStoreDbContext context;
		public CreateOrderCommand(IGameStoreDbContext context) {
			this.context = context;
		}
		public void Handle() {
			Order = new Order();
			Customer? customer = context.Customers.SingleOrDefault(c => c.ID == Model.CustomerID);
			if (customer == null) throw new InvalidOperationException("Customer could not be found.");
			Order.CustomerID = Model.CustomerID;
			Order.CustomerEmail = customer.Email;
			Order.DateTime = DateTime.Now;
			context.Orders.Add(Order);
			context.SaveChanges();
			foreach (int game_ID in Model.GameIDs) {
				Game? game = context.Games.SingleOrDefault(g => g.ID == game_ID);
				if (game == null) throw new InvalidOperationException("Game could not be found.");
				OrderGame order_game = new OrderGame() { OrderID = Order.ID, GameID = game.ID };
				context.OrderGames.Add(order_game);
				Order.Cost += game.Price;
			}
			context.SaveChanges();
		}
		public class CreateOrderModel {
			public int CustomerID { get; set; }
			public IList<int> GameIDs { get; set; } = null!;
		}
	}
}