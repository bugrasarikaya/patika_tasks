using AutoMapper;
using game_store.DBOperations;
using game_store.Entities;
namespace game_store.Application.DeveloperOperations.Commands.CreateDeveloper {
	public class CreateDeveloperCommand {
		public CreateDeveloperModel Model { get; set; } = null!;
		private readonly IGameStoreDbContext context;
		private readonly IMapper mapper;
		public CreateDeveloperCommand(IGameStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public void Handle() {
			Developer? developer = context.Developers.SingleOrDefault(d => d.Name == Model.Name);
			if (developer != null) throw new InvalidOperationException("Developer already exists.");
			developer = mapper.Map<Developer>(Model);
			context.Developers.Add(developer);
			context.SaveChanges();
		}
		public class CreateDeveloperModel {
			public string? Name { get; set; }
			public int Year { get; set; }
		}
	}
}