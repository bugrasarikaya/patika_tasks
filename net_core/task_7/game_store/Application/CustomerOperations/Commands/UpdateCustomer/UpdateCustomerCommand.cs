using game_store.DBOperations;
using game_store.Entities;
namespace game_store.Application.CustomerOperations.Commands.UpdateCustomer {
	public class UpdateCustomerCommand {
		public int CustomerID { get; set; }
		public UpdateCustomerModel Model { get; set; } = null!;
		private readonly IGameStoreDbContext context;
		public UpdateCustomerCommand(IGameStoreDbContext context) {
			this.context = context;
		}
		public void Handle() {
			Customer? customer = context.Customers.SingleOrDefault(c => c.ID == CustomerID);
			if (customer == null) throw new InvalidOperationException("Customer could not be found.");
			customer.Email = Model.Email != default ? Model.Email : customer.Email;
			if (context.Customers.Any(c => c.Email == customer.Email)) throw new InvalidOperationException("Customer email already exists.");
			customer.Password = Model.Password != default ? Model.Password : customer.Password;
			context.SaveChanges();
		}
		public class UpdateCustomerModel {
			public string? Email { get; set; }
			public string? Password { get; set; }
		}
	}
}