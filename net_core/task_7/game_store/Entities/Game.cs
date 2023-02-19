using System.ComponentModel.DataAnnotations.Schema;
namespace game_store.Entities {
	public class Game {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public string? Name { get; set; }
		public int Year { get; set; }
		public double Price { get; set; }
	}
}