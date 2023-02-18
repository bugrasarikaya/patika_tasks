using System.ComponentModel.DataAnnotations.Schema;
namespace movie_store.Entities {
	public class MovieActor {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public int MovieID { get; set; }
		public int ActorID { get; set; }
		//public ICollection<Movie> Movies { get; set; }
		//public ICollection<Actor> Actors { get; set; }
	}
}