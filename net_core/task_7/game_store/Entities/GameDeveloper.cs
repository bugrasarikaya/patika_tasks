using System.ComponentModel.DataAnnotations.Schema;
namespace game_store.Entities {
	public class GameDeveloper {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public int GameID { get; set; }
		public int DeveloperID { get; set; }
	}
}