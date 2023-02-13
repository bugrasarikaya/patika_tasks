using AutoMapper;
using task_4.DBOperations;
namespace task_4.Application.AuthorOperations.Queries.GetAuthors {
    public class GetAuthorsQuery {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAuthorsQuery(IBookStoreDbContext dbContext, IMapper mapper) {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<AuthorsViewModel> Handle() {
            var AuthorList = _dbContext.Authors.OrderBy(x => x.ID).ToList();
            List<AuthorsViewModel> vm = _mapper.Map<List<AuthorsViewModel>>(AuthorList);
            return vm;
        }
    }
    public class AuthorsViewModel {
		public string Name { get; set; }
		public string Surname { get; set; }
		public DateTime DateofBirth { get; set; }
	}
}