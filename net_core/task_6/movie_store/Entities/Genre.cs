using System.ComponentModel.DataAnnotations.Schema;
namespace movie_store.Entities {
	public class Genre {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public string? Name { get; set; }
	}
}