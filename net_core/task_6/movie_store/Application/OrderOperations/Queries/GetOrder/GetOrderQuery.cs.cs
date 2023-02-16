using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
			Order? order = context.Orders.Include(o => o.Customer).Include(o => o.Movies).Where(o => o.ID == OrderID).SingleOrDefault();
			if (order is null) throw new InvalidOperationException("Order could not be found.");
			GetOrderViewModel view_model = mapper.Map<GetOrderViewModel>(order);
			return view_model;
		}
		public class GetOrderViewModel {
			public string? Customer { get; set; }
			public string? Movies { get; set; }
			public double Cost { get; set; }
			public DateTime DateTime { get; set; }
		}
	}
}