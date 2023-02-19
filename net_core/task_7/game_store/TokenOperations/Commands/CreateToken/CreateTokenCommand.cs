using game_store.DBOperations;
using game_store.Entities;
using game_store.TokenOperations.Models;
namespace game_store.TokenOperations.Commands.CreateToken {
	public class CreateTokenCommand {
		public CreateTokenModel Model { get; set; } = null!;
		private readonly IGameStoreDbContext context;
		private readonly IConfiguration configuration;
		public CreateTokenCommand(IGameStoreDbContext context, IConfiguration configuration) {
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
			} else throw new InvalidOperationException("Email or password are incorrect.");
		}
		public class CreateTokenModel {
			public string? Email { get; set; }
			public string? Password { get; set; }
		}
	}
}