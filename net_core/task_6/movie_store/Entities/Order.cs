using System.ComponentModel.DataAnnotations.Schema;
namespace movie_store.Entities {
	public class Order {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public Customer? Customer { get; set; }
		public ICollection<Movie> Movies { get; set; } = new List<Movie>();
		public double Cost { get; set; }
		public DateTime DateTime { get; set; }
	}
}