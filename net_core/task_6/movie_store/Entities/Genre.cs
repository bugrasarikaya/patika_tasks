using System.ComponentModel.DataAnnotations.Schema;
namespace movie_store.Entities {
	public class Genre {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public string? Name { get; set; }
		public ICollection<Customer> Customers { get; set; } = new List<Customer>();
		public ICollection<Movie> Movies { get; set; } = new List<Movie>();
	}
}