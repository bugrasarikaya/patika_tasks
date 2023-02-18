using AutoMapper;
using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.CustomerOperations.Queries.GetCustomers {
	public class GetCustomersQuery {
		private readonly IMovieStoreDbContext context;
		private readonly IMapper mapper;
		public GetCustomersQuery(IMovieStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public List<GetCustomersViewModel> Handle() {
			List<Customer>? list_customer = context.Customers.OrderBy(c => c.ID).ToList();
			List<GetCustomersViewModel> list_view_model = mapper.Map<List<GetCustomersViewModel>>(list_customer);
			foreach (int customer_ID in list_customer.Select(lc => lc.ID)) {
				List<string> list_movie = new List<string>();
				foreach (int order_ID in context.Orders.Where(o => o.CustomerID == customer_ID).Select(o => o.ID)) foreach (int movie_ID in context.OrderMovies.Where(om => om.OrderID == order_ID).Select(m => m.MovieID)) list_movie.Add(context.Movies.SingleOrDefault(m => m.ID == movie_ID)!.Name!);
				list_view_model.SingleOrDefault(lvm => lvm.ID == customer_ID)!.Movies = string.Join(", ", list_movie);
				List<string> list_genre = new List<string>();
				foreach (int genre_ID in context.CustomerGenres.Where(cg => cg.CustomerID == customer_ID).Select(cg => cg.GenreID)) list_genre.Add(context.Genres.SingleOrDefault(g => g.ID == genre_ID)!.Name!);
				list_view_model.SingleOrDefault(lvm => lvm.ID == customer_ID)!.Genres = string.Join(", ", list_genre);
			}
			return list_view_model;
		}
		public class GetCustomersViewModel {
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