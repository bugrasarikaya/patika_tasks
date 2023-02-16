using System.ComponentModel.DataAnnotations.Schema;
namespace movie_store.Entities {
	public class Customer {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public string? Email { get; set; }
		public string? Password { get; set; }
		public string? RefreshToken { get; set; }
		public DateTime? RefreshTokenExpireDate { get; set; }
		public ICollection<Genre> Genres { get; set; } = new List<Genre>();
		public ICollection<Movie> Movies { get; set; } = new List<Movie>();
		public ICollection<Order> Orders { get; set; } = new List<Order>();
	}
}