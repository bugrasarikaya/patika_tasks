using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using task_4.DBOperations;
using task_4.Entities;
namespace task_4.Application.AuthorOperations.Commands.CreateAuthor {
    public class CreateAuthorCommand {
        public CreateAuthorModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateAuthorCommand(BookStoreDbContext dbCOntext, IMapper mapper) {
            _dbContext = dbCOntext;
            _mapper = mapper;
        }
        public void Handle() {
            var Author = new Author();
            Author = _mapper.Map<Author>(Model);
            _dbContext.Authors.Add(Author);
            _dbContext.SaveChanges();
        }
        public class CreateAuthorModel {
			public string Name { get; set; }
			public string Surname { get; set; }
			public DateTime DateofBirth { get; set; }
		}
    }
}