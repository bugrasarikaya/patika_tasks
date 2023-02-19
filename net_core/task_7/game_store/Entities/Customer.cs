using System.ComponentModel.DataAnnotations.Schema;
namespace game_store.Entities {
	public class Customer {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public string? Email { get; set; }
		public string? Password { get; set; }
		public string? RefreshToken { get; set; }
		public DateTime? RefreshTokenExpireDate { get; set; }
	}
}