using Microsoft.EntityFrameworkCore;
using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.CustomerOperations.Commands.DeleteCustomer {
	public class DeleteCustomerCommand {
		private readonly IMovieStoreDbContext context;
		public int CustomerID { get; set; }
		public DeleteCustomerCommand(IMovieStoreDbContext context) {
			this.context = context;
		}
		public void Handle() {
			Customer? customer = context.Customers.SingleOrDefault(m => m.ID == CustomerID);
			if (customer == null) throw new InvalidOperationException("Customer could not be found.");
			context.Customers.Remove(customer);
			context.SaveChanges();
		}
	}
}