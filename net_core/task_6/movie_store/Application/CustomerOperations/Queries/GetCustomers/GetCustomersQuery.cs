using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
			List<Customer>? customer_list = context.Customers.Include(c => c.Movies).Include(c => c.Genres).OrderBy(c => c.ID).ToList();
			List<GetCustomersViewModel> view_model = mapper.Map<List<GetCustomersViewModel>>(customer_list);
			return view_model;
		}
		public class GetCustomersViewModel {
			public string? Name { get; set; }
			public string? Surname { get; set; }
			public string? Movies { get; set; }
			public string? Genres { get; set; }
		}
	}
}