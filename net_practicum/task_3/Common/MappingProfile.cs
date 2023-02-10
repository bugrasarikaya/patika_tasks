using AutoMapper;
using task_4.Application.BookOperations.Queries.GetBookDetail;
using task_4.Application.BookOperations.Queries.GetBooks;
using task_4.Application.GenreOperations.Queries.GetGenreDetail;
using task_4.Application.GenreOperations.Queries.GetGenres;
using task_4.Entities;
using static task_4.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
namespace task_4.Common {
	public class MappingProfile : Profile {
		public MappingProfile() {
			CreateMap<CreateBookModel, Book>();
			CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
			CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
			CreateMap<Genre, GenresViewModel>();
			CreateMap<Genre, GenreDetailViewModel>();
		}
	}
}