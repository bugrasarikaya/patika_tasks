using AutoMapper;
using movie_store.DBOperations;
using movie_store.Entities;
namespace movie_store.Application.CustomerOperations.Commands.CreateCustomer {
	public class CreateCustomerCommand {
		public CreateCustomerModel Model { get; set; } = null!;
		private readonly IMovieStoreDbContext context;
		private readonly IMapper mapper;
		public CreateCustomerCommand(IMovieStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public void Handle() {
			Customer? customer = context.Customers.SingleOrDefault(c => c.Name == Model.Name && c.Surname == Model.Surname);
			if (customer != null) throw new InvalidOperationException("Customer already exists.");
			customer = mapper.Map<Customer>(Model);
			context.Customers.Add(customer);
			context.SaveChanges();
		}
		public class CreateCustomerModel {
			public string? Name { get; set; }
			public string? Surname { get; set; }
		}
	}
}