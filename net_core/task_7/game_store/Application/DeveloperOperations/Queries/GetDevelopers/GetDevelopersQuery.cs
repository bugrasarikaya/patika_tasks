using AutoMapper;
using game_store.DBOperations;
using game_store.Entities;
namespace game_store.Application.DeveloperOperations.Queries.GetDevelopers {
	public class GetDevelopersQuery {
		private readonly IGameStoreDbContext context;
		private readonly IMapper mapper;
		public GetDevelopersQuery(IGameStoreDbContext context, IMapper mapper) {
			this.context = context;
			this.mapper = mapper;
		}
		public List<GetDevelopersViewModel> Handle() {
			List<Developer>? list_developer = context.Developers.OrderBy(d => d.ID).ToList();
			List<GetDevelopersViewModel> list_view_model = mapper.Map<List<GetDevelopersViewModel>>(list_developer);
			foreach (int developer_ID in list_developer.Select(ld => ld.ID)) {
				List<string> list_game = new List<string>();
				foreach (int game_ID in context.GameDevelopers.Where(gd => gd.DeveloperID == developer_ID).Select(gd => gd.GameID)) list_game.Add(context.Games.SingleOrDefault(g => g.ID == game_ID)!.Name!);
				list_view_model.SingleOrDefault(lvm => lvm.ID == developer_ID)!.Games = string.Join(", ", list_game);
			}
			return list_view_model;
		}
		public class GetDevelopersViewModel {
			public int ID { get; set; }
			public string? Name { get; set; }
			public int Year { get; set; }
			public string? Games { get; set; }
		}
	}
}