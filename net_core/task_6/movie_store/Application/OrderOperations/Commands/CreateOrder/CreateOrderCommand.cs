using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.OrderOperations.Commands.CreateOrder {
	public class CreateOrderCommand {
		public CreateOrderModel Model { get; set; } = null!;
		public Order Order { get; set; } = null!;
		private readonly IMovieStoreDbContext context;
		public CreateOrderCommand(IMovieStoreDbContext context) {
			this.context = context;
		}
		public void Handle() {
			Order = new Order();
			Customer? customer = context.Customers.SingleOrDefault(c => c.ID == Model.CustomerID);
			if (customer == null) throw new InvalidOperationException("Customer could not be found.");
			Order.CustomerID = Model.CustomerID;
			Order.Customer = string.Format("{0} {1}", customer.Name, customer.Surname);
			Order.CustomerEmail = customer.Email;
			Order.DateTime = DateTime.Now;
			context.Orders.Add(Order);
			context.SaveChanges();
			foreach (int movie_ID in Model.MovieIDs) {
				Movie? movie = context.Movies.SingleOrDefault(m => m.ID == movie_ID);
				if (movie == null) throw new InvalidOperationException("Movie could not be found.");
				OrderMovie order_movie = new OrderMovie() { OrderID = Order.ID, MovieID = movie.ID};
				context.OrderMovies.Add(order_movie);
				Order.Cost += movie.Price;
			}
			context.SaveChanges();
		}
		public class CreateOrderModel {
			public int CustomerID { get; set; }
			public IList<int> MovieIDs { get; set; } = null!;
		}
	}
}