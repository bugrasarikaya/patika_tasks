using System.ComponentModel.DataAnnotations.Schema;
namespace movie_store.Entities {
	public class MovieDirector {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public int MovieID { get; set; }
		public int DirectorID { get; set; }
		//public ICollection<Movie> Movies { get; set; }
		//public ICollection<Director> Directors { get; set; }
	}
}