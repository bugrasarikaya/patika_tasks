using AutoMapper;
using movie_store.Entities;
using static movie_store.Application.MovieOperations.Commands.CreateMovie.CreateMovieCommand;
using static movie_store.Application.MovieOperations.Queries.GetMovies.GetMoviesQuery;
using static movie_store.Application.MovieOperations.Queries.GetMovie.GetMovieQuery;
using static movie_store.Application.ActorOperations.Commands.CreateActor.CreateActorCommand;
using static movie_store.Application.ActorOperations.Queries.GetActor.GetActorQuery;
using static movie_store.Application.ActorOperations.Queries.GetActors.GetActorsQuery;
using static movie_store.Application.DirectorOperations.Commands.CreateDirector.CreateDirectorCommand;
using static movie_store.Application.DirectorOperations.Queries.GetDirector.GetDirectorQuery;
using static movie_store.Application.DirectorOperations.Queries.GetDirectors.GetDirectorsQuery;
using static movie_store.Application.GenreOperations.Commands.CreateGenre.CreateGenreCommand;
using static movie_store.Application.GenreOperations.Queries.GetGenre.GetGenreQuery;
using static movie_store.Application.GenreOperations.Queries.GetGenres.GetGenresQuery;
using static movie_store.Application.CustomerOperations.Commands.CreateCustomer.CreateCustomerCommand;
using static movie_store.Application.CustomerOperations.Queries.GetCustomers.GetCustomersQuery;
using static movie_store.Application.CustomerOperations.Queries.GetCustomer.GetCustomerQuery;
using static movie_store.Application.OrderOperations.Queries.GetOrder.GetOrderQuery;
using static movie_store.Application.OrderOperations.Queries.GetOrders.GetOrdersQuery;
namespace movie_store.Common {
	public class MappingProfile : Profile {
		public MappingProfile() {
			CreateMap<CreateActorModel, Actor>();
			CreateMap<CreateCustomerModel, Customer>();
			CreateMap<CreateDirectorModel, Director>();
			CreateMap<CreateGenreModel, Genre>();
			CreateMap<CreateMovieModel, Movie>();
			CreateMap<Actor, GetActorViewModel>();
			CreateMap<Actor, GetActorsViewModel>();
			CreateMap<Director, GetDirectorViewModel>();
			CreateMap<Director, GetDirectorsViewModel>();
			CreateMap<Customer, GetCustomerViewModel>();
			CreateMap<Customer, GetCustomersViewModel>();
			CreateMap<Genre, GetGenreViewModel>();
			CreateMap<Genre, GetGenresViewModel>();
			CreateMap<Movie, GetMovieViewModel>();
			CreateMap<Movie, GetMoviesViewModel>();
			CreateMap<Order, GetOrderViewModel>();
			CreateMap<Order, GetOrdersViewModel>();
		}
	}
}