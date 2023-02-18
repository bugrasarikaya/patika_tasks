using AutoMapper;
using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.CustomerOperations.Queries.GetCustomer {
	public class GetCustomerQuery {
		private readonly IMovieStoreDbContext context;
		private readonly IMapper mapper;
		public int CustomerID { get; set; }
		public GetCustomerQuery(IMovieStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public GetCustomerViewModel Handle() {
			Customer? customer = context.Customers.Where(c => c.ID == CustomerID).SingleOrDefault();
			if (customer is null) throw new InvalidOperationException("Customer could not be found.");
			GetCustomerViewModel view_model = mapper.Map<GetCustomerViewModel>(customer);
			List<string> list_movie = new List<string>();
			foreach (int order_ID in context.Orders.Where(o => o.CustomerID == CustomerID).Select(o => o.ID)) foreach (int movie_ID in context.OrderMovies.Where(om => om.OrderID == order_ID).Select(m => m.MovieID)) list_movie.Add(context.Movies.SingleOrDefault(m => m.ID == movie_ID)!.Name!);
			view_model.Movies = string.Join(", ", list_movie);
			List<string> list_genre = new List<string>();
			foreach (int genre_ID in context.CustomerGenres.Where(cg => cg.CustomerID == CustomerID).Select(cg => cg.GenreID)) list_genre.Add(context.Genres.SingleOrDefault(g => g.ID == genre_ID)!.Name!);
			view_model.Genres = string.Join(", ", list_genre);
			return view_model;
		}
		public class GetCustomerViewModel {
			public int ID { get; set; }
			public string? Name { get; set; }
			public string? Surname { get; set; }
			public string? Email { get; set; }
			public string? Password { get; set; }
			public string? Movies { get; set; }
			public string? Genres { get; set; }
		}
	}
}