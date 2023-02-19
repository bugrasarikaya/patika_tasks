using game_store.DBOperations;
using game_store.Entities;
namespace game_store.Application.PublisherOperations.Commands.UpdatePublisher {
	public class UpdatePublisherCommand {
		public int PublisherID { get; set; }
		public UpdatePublisherModel Model { get; set; } = null!;
		private readonly IGameStoreDbContext context;
		public UpdatePublisherCommand(IGameStoreDbContext context) {
			this.context = context;
		}
		public void Handle() {
			Publisher? developer = context.Publishers.SingleOrDefault(p => p.ID == PublisherID);
			if (developer == null) throw new InvalidOperationException("Publisher could not be found.");
			developer.Name = Model.Name != default ? Model.Name : developer.Name;
			developer.Year = Model.Year != default ? Model.Year : developer.Year;
			if (context.Publishers.Any(p => p.Name == developer.Name)) throw new InvalidOperationException("Publisher already exists.");
			context.SaveChanges();
		}
		public class UpdatePublisherModel {
			public string? Name { get; set; }
			public int Year { get; set; }
		}
	}
}