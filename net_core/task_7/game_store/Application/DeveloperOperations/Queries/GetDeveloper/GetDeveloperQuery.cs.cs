using AutoMapper;
using game_store.DBOperations;
using game_store.Entities;
namespace game_store.Application.DeveloperOperations.Queries.GetDeveloper {
	public class GetDeveloperQuery {
		private readonly IGameStoreDbContext context;
		private readonly IMapper mapper;
		public int DeveloperID { get; set; }
		public GetDeveloperQuery(IGameStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public GetDeveloperViewModel Handle() {
			Developer? developer = context.Developers.Where(d => d.ID == DeveloperID).SingleOrDefault();
			if (developer is null) throw new InvalidOperationException("Developer could not be found.");
			GetDeveloperViewModel view_model = mapper.Map<GetDeveloperViewModel>(developer);
			List<string> list_game = new List<string>();
			foreach (int game_ID in context.GameDevelopers.Where(gd => gd.DeveloperID == DeveloperID).Select(gd => gd.GameID)) list_game.Add(context.Games.SingleOrDefault(g => g.ID == game_ID)!.Name!);
			view_model.Games = string.Join(", ", list_game);
			return view_model;
		}
		public class GetDeveloperViewModel {
			public int ID { get; set; }
			public string? Name { get; set; }
			public int Year { get; set; }
			public string? Games { get; set; }
		}
	}
}