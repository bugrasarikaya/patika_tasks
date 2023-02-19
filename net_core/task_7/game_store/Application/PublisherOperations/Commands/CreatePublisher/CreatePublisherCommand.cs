using AutoMapper;
using game_store.DBOperations;
using game_store.Entities;
namespace game_store.Application.PublisherOperations.Commands.CreatePublisher {
	public class CreatePublisherCommand {
		public CreatePublisherModel Model { get; set; } = null!;
		private readonly IGameStoreDbContext context;
		private readonly IMapper mapper;
		public CreatePublisherCommand(IGameStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public void Handle() {
			Publisher? publisher = context.Publishers.SingleOrDefault(p => p.Name == Model.Name);
			if (publisher != null) throw new InvalidOperationException("Publisher already exists.");
			publisher = mapper.Map<Publisher>(Model);
			context.Publishers.Add(publisher);
			context.SaveChanges();
		}
		public class CreatePublisherModel {
			public string? Name { get; set; }
			public int Year { get; set; }
		}
	}
}