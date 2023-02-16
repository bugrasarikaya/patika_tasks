using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
			List<Order>? order_list = context.Orders.Include(o => o.Customer).Include(o => o.Movies).OrderBy(o => o.ID).ToList();
			List<GetOrdersViewModel> view_model = mapper.Map<List<GetOrdersViewModel>>(order_list);
			return view_model;
		}
		public class GetOrdersViewModel {
			public string? Customer { get; set; }
			public string? Movies { get; set; }
			public double Cost { get; set; }
			public DateTime DateTime { get; set; }
		}
	}
}