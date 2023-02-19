using game_store.DBOperations;
using game_store.Entities;
using game_store.TokenOperations.Models;
namespace game_store.TokenOperations.Commands.RefreshToken {
	public class RefreshTokenCommand {
		public string refresh_token { get; set; } = null!;
		private readonly IGameStoreDbContext context;
		private readonly IConfiguration configuration;
		public RefreshTokenCommand(IGameStoreDbContext context, IConfiguration configuration) {
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
			} else throw new InvalidOperationException("Any valid refresh token could not be found.");
		}
	}
}