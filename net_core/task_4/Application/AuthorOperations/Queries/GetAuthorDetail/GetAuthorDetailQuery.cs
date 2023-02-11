using AutoMapper;
using task_4.DBOperations;
namespace task_4.Application.AuthorOperations.Queries.GetAuthorDetail {
    public class GetAuthorDetailQuery {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int AuthorID { get; set; }
        public GetAuthorDetailQuery(BookStoreDbContext dbContext, IMapper mapper) {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public AuthorDetailViewModel Handle() {
            var Author = _dbContext.Authors.Where(Author => Author.ID == AuthorID).SingleOrDefault();
            if (Author is null) throw new InvalidOperationException("Yazar Bulunamadı!");
            AuthorDetailViewModel vm = _mapper.Map<AuthorDetailViewModel>(Author);
            return vm;
        }
    }
    public class AuthorDetailViewModel {
		public string Name { get; set; }
		public string Surname { get; set; }
		public DateTime DateofBirth { get; set; }
	}
}