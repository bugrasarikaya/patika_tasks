using AutoMapper;
using FluentAssertions;
using game_store.Application.DeveloperOperations.Queries.GetDeveloper;
using game_store.DBOperations;
using game_store.Entities;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.DeveloperOperations.Queries.GetDeveloper {
	public class GetDeveloperDetailQueryTests : IClassFixture<CommonTestFixture> {
		private readonly GameStoreDbContext context;
		private readonly IMapper mapper;
		public GetDeveloperDetailQueryTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
			mapper = test_fixture.Mapper;
		}
		[Fact]
		public void WhenNotExistDeveloperIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			GetDeveloperQuery query = new GetDeveloperQuery(context, mapper);
			query.DeveloperID = 0;
			FluentActions
				.Invoking(() => query.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Developer could not be found.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Developer_ShouldBeReturn() {
			GetDeveloperQuery query = new GetDeveloperQuery(context, mapper);
			query.DeveloperID = 1;
			FluentActions.Invoking(() => query.Handle()).Invoke();
			Developer? developer = context.Developers.SingleOrDefault(d => d.ID == query.DeveloperID);
			developer.Should().NotBeNull();
		}
	}
}