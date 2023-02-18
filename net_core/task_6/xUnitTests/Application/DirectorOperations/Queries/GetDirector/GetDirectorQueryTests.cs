using AutoMapper;
using FluentAssertions;
using movie_store.Application.DirectorOperations.Queries.GetDirector;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.DirectorOperations.Queries.GetDirector {
	public class GetDirectorDetailQueryTests : IClassFixture<CommonTestFixture> {
		private readonly MovieStoreDbContext context;
		private readonly IMapper mapper;
		public GetDirectorDetailQueryTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
			mapper = test_fixture.Mapper;
		}
		[Fact]
		public void WhenNotExistDirectorIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			GetDirectorQuery query = new GetDirectorQuery(context, mapper);
			query.DirectorID = 0;
			FluentActions
				.Invoking(() => query.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Director could not be found.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Director_ShouldBeReturn() {
			GetDirectorQuery query = new GetDirectorQuery(context, mapper);
			query.DirectorID = 1;
			FluentActions.Invoking(() => query.Handle()).Invoke();
			Director? director = context.Directors.SingleOrDefault(d => d.ID == query.DirectorID);
			director.Should().NotBeNull();
		}
	}
}