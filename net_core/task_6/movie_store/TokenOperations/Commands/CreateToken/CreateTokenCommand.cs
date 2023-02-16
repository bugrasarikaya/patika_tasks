using movie_store.DBOperations;
using movie_store.Entities;
using movie_store.TokenOperations.Models;
namespace movie_store.TokenOperations.Commands.CreateToken {
	public class CreateTokenCommand {
		public CreateTokenModel Model { get; set; } = null!;
		private readonly IMovieStoreDbContext context;
		private readonly IConfiguration configuration;
		public CreateTokenCommand(IMovieStoreDbContext context, IConfiguration configuration) {
			this.context = context;
			this.configuration = configuration;
		}
		public Token Handle() {
			Customer? customer = context.Customers.SingleOrDefault(c => c.Email == Model.Email && c.Password == Model.Password);
			if (customer != null) {
				TokenHandler handler = new TokenHandler(configuration);
				Token token = handler.CreateAccessToken(customer);
				customer.RefreshToken = token.RefreshToken;
				customer.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
				context.SaveChanges();
				return token;
			}
			else throw new InvalidOperationException("Email or password are incorrect.");
		}
		public class CreateTokenModel {
			public string? Email { get; set; }
			public string? Password { get; set; }
		}
	}
}