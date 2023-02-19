using AutoMapper;
using game_store.Entities;
using static game_store.Application.GameOperations.Commands.CreateGame.CreateGameCommand;
using static game_store.Application.GameOperations.Queries.GetGames.GetGamesQuery;
using static game_store.Application.GameOperations.Queries.GetGame.GetGameQuery;
using static game_store.Application.DeveloperOperations.Commands.CreateDeveloper.CreateDeveloperCommand;
using static game_store.Application.DeveloperOperations.Queries.GetDeveloper.GetDeveloperQuery;
using static game_store.Application.DeveloperOperations.Queries.GetDevelopers.GetDevelopersQuery;
using static game_store.Application.PublisherOperations.Commands.CreatePublisher.CreatePublisherCommand;
using static game_store.Application.PublisherOperations.Queries.GetPublisher.GetPublisherQuery;
using static game_store.Application.PublisherOperations.Queries.GetPublishers.GetPublishersQuery;
using static game_store.Application.CustomerOperations.Commands.CreateCustomer.CreateCustomerCommand;
using static game_store.Application.CustomerOperations.Queries.GetCustomers.GetCustomersQuery;
using static game_store.Application.CustomerOperations.Queries.GetCustomer.GetCustomerQuery;
using static game_store.Application.OrderOperations.Queries.GetOrder.GetOrderQuery;
using static game_store.Application.OrderOperations.Queries.GetOrders.GetOrdersQuery;
namespace game_store.Common {
	public class MappingProfile : Profile {
		public MappingProfile() {
			CreateMap<CreateDeveloperModel, Developer>();
			CreateMap<CreateCustomerModel, Customer>();
			CreateMap<CreatePublisherModel, Publisher>();
			CreateMap<CreateGameModel, Game>();
			CreateMap<Developer, GetDeveloperViewModel>();
			CreateMap<Developer, GetDevelopersViewModel>();
			CreateMap<Publisher, GetPublisherViewModel>();
			CreateMap<Publisher, GetPublishersViewModel>();
			CreateMap<Customer, GetCustomerViewModel>();
			CreateMap<Customer, GetCustomersViewModel>();
			CreateMap<Game, GetGameViewModel>();
			CreateMap<Game, GetGamesViewModel>();
			CreateMap<Order, GetOrderViewModel>();
			CreateMap<Order, GetOrdersViewModel>();
		}
	}
}