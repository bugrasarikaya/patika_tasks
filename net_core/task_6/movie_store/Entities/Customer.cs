using System.ComponentModel.DataAnnotations.Schema;
namespace movie_store.Entities {
	public class Customer {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public ICollection<Movie> Movies { get; set; } = new List<Movie>();
		public ICollection<Genre> Genres { get; set; } = new List<Genre>();
	}
}