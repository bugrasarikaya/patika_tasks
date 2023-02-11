using AutoMapper;
using task_4.Application.AuthorOperations.Queries.GetAuthorDetail;
using task_4.Application.AuthorOperations.Queries.GetAuthors;
using task_4.Application.BookOperations.Queries.GetBookDetail;
using task_4.Application.BookOperations.Queries.GetBooks;
using task_4.Application.GenreOperations.Queries.GetGenreDetail;
using task_4.Application.GenreOperations.Queries.GetGenres;
using task_4.Entities;
using static task_4.Application.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;
using static task_4.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
namespace task_4.Common {
	public class MappingProfile : Profile {
		public MappingProfile() {
			CreateMap<CreateAuthorModel, Author>();
			CreateMap<CreateBookModel, Book>();
			CreateMap<Author, AuthorDetailViewModel>();
			CreateMap<Author, AuthorsViewModel>();
			CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Author, opt => opt.MapFrom(src => string.Format("{0} {1}", src.Author.Name, src.Author.Surname)));
			CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Author, opt => opt.MapFrom(src => string.Format("{0} {1}", src.Author.Name, src.Author.Surname)));
			CreateMap<Genre, GenresViewModel>();
			CreateMap<Genre, GenreDetailViewModel>();
		}
	}
}