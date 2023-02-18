using System.ComponentModel.DataAnnotations.Schema;
namespace movie_store.Entities {
	public class MovieGenre {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public int MovieID { get; set; }
		public int GenreID { get; set; }
		//public ICollection<Movie> Movies { get; set; }
		//public ICollection<Genre> Genres { get; set; }
	}
}