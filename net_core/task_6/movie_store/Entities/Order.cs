using System.ComponentModel.DataAnnotations.Schema;
namespace movie_store.Entities {
	public class Order {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public int CustomerID { get; set; }
		public string? Customer { get; set; }
		public string? CustomerEmail { get; set; }
		public DateTime DateTime { get; set; }
		public double Cost { get; set; }
	}
}