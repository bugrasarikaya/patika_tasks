using System.ComponentModel.DataAnnotations.Schema;
namespace movie_store.Entities {
	public class OrderMovie {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public int OrderID { get; set; }
		public int MovieID { get; set; }
		//public Order Order { get; set; }
		//public ICollection<Movie> Movies { get; set; }
	}
}