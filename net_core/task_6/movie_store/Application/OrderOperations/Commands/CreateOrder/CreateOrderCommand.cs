using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.OrderOperations.Commands.CreateOrder {
	public class CreateOrderCommand {
		public CreateOrderModel Model { get; set; } = null!;
		private readonly IMovieStoreDbContext context;
		public CreateOrderCommand(IMovieStoreDbContext context) {
			this.context = context;
		}
		public void Handle() {
			Order order = new Order();
			Customer? customer = context.Customers.SingleOrDefault(c => c.ID == Model.CustomerID);
			if (customer == null) throw new InvalidOperationException("Customer could not be found.");
			order.Customer = customer;
			foreach (int movie_ID in Model.MovieIDs) {
				Movie? movie = context.Movies.SingleOrDefault(m => m.ID == movie_ID);
				if (movie == null) throw new InvalidOperationException("Movie could not be found.");
				order.Movies.Add(movie);
				order.Cost += movie.Price;
			}
			order.DateTime = DateTime.Now;
			context.Orders.Add(order);
			context.SaveChanges();
		}
		public class CreateOrderModel {
			public int CustomerID { get; set; }
			public IList<int> MovieIDs { get; set; } = null!;
		}
	}
}