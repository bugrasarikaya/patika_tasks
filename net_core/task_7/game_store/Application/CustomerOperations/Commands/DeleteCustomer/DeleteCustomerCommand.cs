using game_store.DBOperations;
using game_store.Entities;
namespace game_store.Application.CustomerOperations.Commands.DeleteCustomer {
	public class DeleteCustomerCommand {
		private readonly IGameStoreDbContext context;
		public int CustomerID { get; set; }
		public DeleteCustomerCommand(IGameStoreDbContext context) {
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