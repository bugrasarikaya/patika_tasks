using Microsoft.EntityFrameworkCore;
using game_store.Entities;
namespace game_store.DBOperations {
	public interface IGameStoreDbContext {
		DbSet<Customer> Customers { get; set; }
		DbSet<Developer> Developers { get; set; }
		DbSet<Game> Games { get; set; }
		DbSet<GameDeveloper> GameDevelopers { get; set; }
		DbSet<GamePublisher> GamePublishers { get; set; }
		DbSet<Order> Orders { get; set; }
		DbSet<OrderGame> OrderGames { get; set; }
		DbSet<Publisher> Publishers { get; set; }
		int SaveChanges();
	}
}