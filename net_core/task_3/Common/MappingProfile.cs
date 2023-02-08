using AutoMapper;
using task_3.BookOperations.GetBookDetail;
using task_3.BookOperations.GetBooks;
using static task_3.BookOperations.CreateBook.CreateBookCommand;
using static task_3.Common.GenerateEnum;
namespace task_3.Common {
	public class MappingProfile : Profile {
		public MappingProfile() {
			CreateMap<CreateBookModel, Book>();
			CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreID).ToString()));
			CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreID).ToString()));
		}
	}
}