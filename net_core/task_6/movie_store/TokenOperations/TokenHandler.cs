using Microsoft.IdentityModel.Tokens;
using movie_store.Entities;
using movie_store.TokenOperations.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace movie_store.TokenOperations {
	public class TokenHandler {
		public IConfiguration Configuration { get; set; }
		public TokenHandler(IConfiguration configuration) {
			Configuration = configuration;
		}
		public Token CreateAccessToken(Customer customer) {
			Token token_model = new Token();
			SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));
			SigningCredentials signing_credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			token_model.Expiration = DateTime.Now.AddMinutes(15);
			JwtSecurityToken security_token = new JwtSecurityToken(
				issuer: Configuration["Token:Issuer"],
				audience: Configuration["Token:Audience"],
				expires: token_model.Expiration,
				notBefore: DateTime.Now,
				signingCredentials: signing_credentials
			);
			JwtSecurityTokenHandler token_handler = new JwtSecurityTokenHandler();
			token_model.AccessToken = token_handler.WriteToken(security_token);
			token_model.RefreshToken = CreateRefreshToken();
			return token_model;
		}
		public string CreateRefreshToken() {
			return Guid.NewGuid().ToString();
		}
	}
}
