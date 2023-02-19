using game_store.DBOperations;
using game_store.Entities;
namespace game_store.Application.PublisherOperations.Commands.DeletePublisher {
	public class DeletePublisherCommand {
		private readonly IGameStoreDbContext context;
		public int PublisherID { get; set; }
		public DeletePublisherCommand(IGameStoreDbContext context) {
			this.context = context;
		}
		public void Handle() {
			Publisher? publisher = context.Publishers.SingleOrDefault(p => p.ID == PublisherID);
			if (publisher == null) throw new InvalidOperationException("Publisher could not be found.");
			if (context.GamePublishers.Any(gp => gp.PublisherID == PublisherID)) throw new InvalidOperationException("Publisher exists in a game.");
			context.Publishers.Remove(publisher);
			context.SaveChanges();
		}
	}
}