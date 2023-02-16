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
			Customer? customer = context.Customers.SingleOrDefault(m => m.ID == CustomerID);
			if (customer == null) throw new InvalidOperationException("Customer could not be found.");
			customer.Name = Model.Name != default ? Model.Name : customer.Name;
			customer.Surname = Model.Surname != default ? Model.Surname : customer.Surname;
			customer.Movies.Clear();
			foreach (int movie_ID in Model.MovieIDs) {
				Movie? movie = context.Movies.SingleOrDefault(m => m.ID == movie_ID);
				if (movie == null) throw new InvalidOperationException("Movie could not be found.");
				customer.Movies.Add(movie);
			}
			customer.Genres.Clear();
			foreach (int genre_ID in Model.GenreIDs) {
				Genre? genre = context.Genres.SingleOrDefault(g => g.ID == genre_ID);
				if (genre == null) throw new InvalidOperationException("Genre could not be found.");
				customer.Genres.Add(genre);
			}
			context.SaveChanges();
		}
		public class UpdateCustomerModel {
			public string? Name { get; set; }
			public string? Surname { get; set; }
			public List<int> MovieIDs { get; set; } = null!;
			public List<int> GenreIDs { get; set; } = null!;
		}
	}
}