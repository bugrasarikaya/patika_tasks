using AutoMapper;
using FluentAssertions;
using System.Xml.Linq;
using movie_store.Application.AuthorOperations.Commands.CreateAuthor;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
using static movie_store.Application.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;
namespace xUnitTests.Application.AuthorOperations.Commands.CreateAuthor {
	public class CreateAuthorCommandTests : IClassFixture<CommonTestFixture> {
		private readonly BookStoreDbContext _context;
		private readonly IMapper _mapper;
		public CreateAuthorCommandTests(CommonTestFixture testFixture) {
			_context = testFixture.context;
			_mapper = testFixture.Mapper;
		}
		[Fact]
		public void WhenValidInputAreGiven_Author_ShouldBeCreated() {
			CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
			CreateAuthorModel model = new CreateAuthorModel() { Name = "Andrzej", Surname = "Sapkowski", DateofBirth = new DateTime(1946, 06, 21) };
			command.Model = model;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			var Author = _context.Authors.FirstOrDefault(Author => Author.Name == model.Name && Author.Surname == model.Surname && Author.DateofBirth == model.DateofBirth);
			Author.Should().NotBeNull();
			Author.Name.Should().Be(model.Name);
			Author.Surname.Should().Be(model.Surname);
			Author.DateofBirth.Should().Be(model.DateofBirth);
		}
	}
}