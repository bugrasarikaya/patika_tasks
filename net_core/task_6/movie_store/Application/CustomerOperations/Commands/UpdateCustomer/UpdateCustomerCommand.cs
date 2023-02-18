using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.CustomerOperations.Commands.UpdateCustomer {
	public class UpdateCustomerCommand {
		public int CustomerID { get; set; }
		public UpdateCustomerModel Model { get; set; } = null!;
		private readonly IMovieStoreDbContext context;
		public UpdateCustomerCommand(IMovieStoreDbContext context) {
			this.context = context;
		}
		public void Handle() {
			Customer? customer = context.Customers.SingleOrDefault(c => c.ID == CustomerID);
			if (customer == null) throw new InvalidOperationException("Customer could not be found.");
			customer.Name = Model.Name != default ? Model.Name : customer.Name;
			customer.Surname = Model.Surname != default ? Model.Surname : customer.Surname;
			customer.Email = Model.Email != default ? Model.Email : customer.Email;
			if (context.Customers.Any(c => c.Email == customer.Email)) throw new InvalidOperationException("Customer email already exists.");
			customer.Password = Model.Password != default ? Model.Password : customer.Password;
			context.CustomerGenres.RemoveRange(context.CustomerGenres.Where(cg => cg.CustomerID == CustomerID));
			foreach (int genre_ID in Model.GenreIDs) {
				if (!context.Genres.Any(g => g.ID == genre_ID)) throw new InvalidOperationException("Genre could not be found.");
				context.CustomerGenres.Add(new CustomerGenre { CustomerID = CustomerID, GenreID = genre_ID });
			}
			context.SaveChanges();
		}
		public class UpdateCustomerModel {
			public string? Name { get; set; }
			public string? Surname { get; set; }
			public string? Email { get; set; }
			public string? Password { get; set; }
			public List<int> GenreIDs { get; set; } = null!;
		}
	}
}