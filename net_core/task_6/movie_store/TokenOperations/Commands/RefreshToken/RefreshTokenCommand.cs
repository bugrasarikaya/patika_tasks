using movie_store.DBOperations;
using movie_store.Entities;
using movie_store.TokenOperations.Models;
namespace movie_store.TokenOperations.Commands.RefreshToken {
	public class RefreshTokenCommand {
		public string refresh_token { get; set; } = null!;
		private readonly IMovieStoreDbContext context;
		private readonly IConfiguration configuration;
		public RefreshTokenCommand(IMovieStoreDbContext context, IConfiguration configuration) {
			this.context = context;
			this.configuration = configuration;
		}
		public Token Handle() {
			Customer? customer = context.Customers.SingleOrDefault(c => c.RefreshToken == refresh_token && c.RefreshTokenExpireDate > DateTime.Now);
			if (customer != null) {
				TokenHandler handler = new TokenHandler(configuration);
				Token token = handler.CreateAccessToken(customer);
				customer.RefreshToken = token.RefreshToken;
				customer.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
				context.SaveChanges();
				return token;
			}
			else throw new InvalidOperationException("Any valid refresh token could not be found.");
		}
	}
}