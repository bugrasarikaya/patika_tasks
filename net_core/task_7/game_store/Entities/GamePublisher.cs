using System.ComponentModel.DataAnnotations.Schema;
namespace game_store.Entities {
	public class GamePublisher {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public int GameID { get; set; }
		public int PublisherID { get; set; }
	}
}