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
			CreateMap<Actor, GetActorViewModel>().ForMember(dest => dest.Movies, opt => opt.MapFrom(src => string.Join(", ", src.Movies.Select(m => m.Name))));
			CreateMap<Actor, GetActorsViewModel>().ForMember(dest => dest.Movies, opt => opt.MapFrom(src => string.Join(", ", src.Movies.Select(m => m.Name))));
			CreateMap<Director, GetDirectorViewModel>().ForMember(dest => dest.Movies, opt => opt.MapFrom(src => string.Join(", ", src.Movies.Select(m => m.Name))));
			CreateMap<Director, GetDirectorsViewModel>().ForMember(dest => dest.Movies, opt => opt.MapFrom(src => string.Join(", ", src.Movies.Select(m => m.Name))));
			CreateMap<Customer, GetCustomerViewModel>().ForMember(dest => dest.Movies, opt => opt.MapFrom(src => string.Join(", ", src.Movies.Select(m => m.Name)))).ForMember(dest => dest.Genres, opt => opt.MapFrom(src => string.Join(", ", src.Genres.Select(g => g.Name))));
			CreateMap<Customer, GetCustomersViewModel>().ForMember(dest => dest.Movies, opt => opt.MapFrom(src => string.Join(", ", src.Movies.Select(m => m.Name)))).ForMember(dest => dest.Genres, opt => opt.MapFrom(src => string.Join(", ", src.Genres.Select(g => g.Name))));
			CreateMap<Genre, GetGenreViewModel>();
			CreateMap<Genre, GetGenresViewModel>();
			CreateMap<Movie, GetMovieViewModel>().ForMember(dest => dest.Genres, opt => opt.MapFrom(src => string.Join(", ", src.Genres.Select(g => g.Name)))).ForMember(dest => dest.Director, opt => opt.MapFrom(src => string.Format("{0} {1}", src.Director.Name, src.Director.Surname))).ForMember(dest => dest.Actors, opt => opt.MapFrom(src => string.Join(", ", src.Actors.Select(a => string.Format("{0} {1}", a.Name, a.Surname)))));
			CreateMap<Movie, GetMoviesViewModel>().ForMember(dest => dest.Genres, opt => opt.MapFrom(src => string.Join(", ", src.Genres.Select(g => g.Name)))).ForMember(dest => dest.Director, opt => opt.MapFrom(src => string.Format("{0} {1}", src.Director.Name, src.Director.Surname))).ForMember(dest => dest.Actors, opt => opt.MapFrom(src => string.Join(", ", src.Actors.Select(a => string.Format("{0} {1}", a.Name, a.Surname)))));
			CreateMap<Order, GetOrderViewModel>().ForMember(dest => dest.Customer, opt => opt.MapFrom(src => string.Format("{0} {1}", src.Customer.Name, src.Customer.Surname))).ForMember(dest => dest.Movies, opt => opt.MapFrom(src => string.Join(", ", src.Movies.Select(m => m.Name))));
			CreateMap<Order, GetOrdersViewModel>().ForMember(dest => dest.Customer, opt => opt.MapFrom(src => string.Format("{0} {1}", src.Customer.Name, src.Customer.Surname))).ForMember(dest => dest.Movies, opt => opt.MapFrom(src => string.Join(", ", src.Movies.Select(m => m.Name))));
		}
	}
}