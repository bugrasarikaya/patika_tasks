using AutoMapper;
using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.OrderOperations.Queries.GetOrders {
	public class GetOrdersQuery {
		private readonly IMovieStoreDbContext context;
		private readonly IMapper mapper;
		public GetOrdersQuery(IMovieStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public List<GetOrdersViewModel> Handle() {
			List<Order>? list_order = context.Orders.OrderBy(o => o.ID).ToList();
			List<GetOrdersViewModel> list_view_model = mapper.Map<List<GetOrdersViewModel>>(list_order);
			foreach (int order_ID in list_order.Select(lo => lo.ID)) {
				List<string> list_movie = new List<string>();
				foreach (int movie_ID in context.OrderMovies.Where(om => om.OrderID == order_ID).Select(m => m.MovieID)) list_movie.Add(context.Movies.SingleOrDefault(m => m.ID == movie_ID)!.Name!);
				list_view_model.SingleOrDefault(lvm => lvm.ID == order_ID)!.Movies = string.Join(", ", list_movie);
			}
			return list_view_model;
		}
		public class GetOrdersViewModel {
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