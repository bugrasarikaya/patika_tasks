using System.ComponentModel.DataAnnotations.Schema;
namespace game_store.Entities {
	public class Developer {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public string? Name { get; set; }
		public int Year { get; set; }
	}
}