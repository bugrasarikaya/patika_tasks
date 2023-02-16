using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
			Customer? customer = context.Customers.Include(c => c.Movies).Include(c => c.Genres).Where(c => c.ID == CustomerID).SingleOrDefault();
			if (customer is null) throw new InvalidOperationException("Customer could not be found.");
			GetCustomerViewModel view_model = mapper.Map<GetCustomerViewModel>(customer);
			return view_model;
		}
		public class GetCustomerViewModel {
			public string? Name { get; set; }
			public string? Surname { get; set; }
			public string? Email { get; set; }
			public string? Password { get; set; }
			public string? Movies { get; set; }
			public string? Genres { get; set; }
		}
	}
}