using AutoMapper;
using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.OrderOperations.Queries.GetOrder {
	public class GetOrderQuery {
		private readonly IMovieStoreDbContext context;
		private readonly IMapper mapper;
		public int OrderID { get; set; }
		public GetOrderQuery(IMovieStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public GetOrderViewModel Handle() {
			Order? order = context.Orders.Where(o => o.ID == OrderID).SingleOrDefault();
			if (order is null) throw new InvalidOperationException("Order could not be found.");
			GetOrderViewModel view_model = mapper.Map<GetOrderViewModel>(order);
			List<string> list_movie = new List<string>();
			foreach (int movie_ID in context.OrderMovies.Where(om => om.OrderID == OrderID).Select(m => m.MovieID)) list_movie.Add(context.Movies.SingleOrDefault(m => m.ID == movie_ID)!.Name!);
			view_model.Movies = string.Join(", ", list_movie);
			return view_model;
		}
		public class GetOrderViewModel {
			public int ID { get; set; }
			public int CustomerID { get; set; }
			public string? Customer { get; set; }
			public string? CustomerEmail { get; set; }
			public string? Movies { get; set; }
			public double Cost { get; set; }
			public DateTime DateTime { get; set; }
		}
	}
}