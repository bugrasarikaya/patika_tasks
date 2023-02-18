using System.ComponentModel.DataAnnotations.Schema;
namespace movie_store.Entities {
	public class Movie {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public string? Name { get; set; }
		public int Year { get; set; }
		public double Price { get; set; }
	}
}