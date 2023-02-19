using Microsoft.EntityFrameworkCore;
using game_store.Entities;
namespace game_store.DBOperations {
	public class DataGenerator {
		public static void Initialize(IServiceProvider serviceProvider) {
			using (var context = new GameStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<GameStoreDbContext>>())) {
				context.Customers.AddRange(
					new Customer { ID = 1, Email = "ashrivers@schrecknet.vtm", Password = "12345678" },
					new Customer { ID = 2, Email = "heatherpoe@schrecknet.vtm", Password = "12345678" }
				);
				context.Developers.AddRange(
					new Developer { ID = 1, Name = "id Software", Year = 1991 },
					new Developer { ID = 2, Name = "Valve", Year = 1996 },
					new Developer { ID = 3, Name = "Gearbox Software", Year = 1999 }
				);
				context.Games.AddRange(
					new Game { ID = 1, Name = "DOOM Eternal", Year = 2020, Price = 39.99 },
					new Game { ID = 2, Name = "Half-Life 2", Year = 2004, Price = 9.99 },
					new Game { ID = 3, Name = "Borderlands 2", Year = 2012, Price = 19.99 }
				);
				context.GameDevelopers.AddRange(
					new GameDeveloper { ID = 1, GameID = 1, DeveloperID = 1 },
					new GameDeveloper { ID = 2, GameID = 2, DeveloperID = 2 },
					new GameDeveloper { ID = 3, GameID = 3, DeveloperID = 3 }
				);
				context.GamePublishers.AddRange(
					new GamePublisher { ID = 1, GameID = 1, PublisherID = 1 },
					new GamePublisher { ID = 2, GameID = 2, PublisherID = 2 },
					new GamePublisher { ID = 3, GameID = 3, PublisherID = 3 }
				);
				context.Orders.AddRange(
					new Order { ID = 1, CustomerID = 1, CustomerEmail = "ashrivers@schrecknet.vtm", DateTime = new DateTime(2021, 01, 01), Cost = 39.99 + 19.99 },
					new Order { ID = 2, CustomerID = 2, CustomerEmail = "heatherpoe@schrecknet.vtm", DateTime = new DateTime(2021, 01, 02), Cost = 9.99 }
				);
				context.OrderGames.AddRange(
					new OrderGame { ID = 1, OrderID = 1, GameID = 1 },
					new OrderGame { ID = 2, OrderID = 1, GameID = 3 },
					new OrderGame { ID = 3, OrderID = 2, GameID = 2 }
				);
				context.Publishers.AddRange(
					new Publisher { ID = 1, Name = "Bethesda Softworks", Year = 1986 },
					new Publisher { ID = 2, Name = "Valve", Year = 1996 },
					new Publisher { ID = 3, Name = "2K", Year = 2005 }
				);
				context.SaveChanges();
			}
		}
	}
}