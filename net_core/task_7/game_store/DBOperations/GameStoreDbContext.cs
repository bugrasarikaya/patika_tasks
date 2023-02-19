using Microsoft.EntityFrameworkCore;
using game_store.Entities;
namespace game_store.DBOperations {
	public class GameStoreDbContext : DbContext, IGameStoreDbContext {
		public GameStoreDbContext(DbContextOptions<GameStoreDbContext> options) : base(options) { }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Developer> Developers { get; set; }
		public DbSet<Game> Games { get; set; }
		public DbSet<GameDeveloper> GameDevelopers { get; set; }
		public DbSet<GamePublisher> GamePublishers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderGame> OrderGames { get; set; }
		public DbSet<Publisher> Publishers { get; set; }
		public override int SaveChanges() {
			return base.SaveChanges();
		}
	}
}