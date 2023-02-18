using System.ComponentModel.DataAnnotations.Schema;
namespace movie_store.Entities {
	public class CustomerGenre {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public int CustomerID { get; set; }
		public int GenreID { get; set; }
		//public Customer Customer { get; set; }
		//public ICollection<Genre> Genres { get; set; }
	}
}