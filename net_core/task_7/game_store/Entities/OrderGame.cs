using System.ComponentModel.DataAnnotations.Schema;
namespace game_store.Entities {
	public class OrderGame {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public int OrderID { get; set; }
		public int GameID { get; set; }
	}
}