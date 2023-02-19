using AutoMapper;
using FluentAssertions;
using game_store.Application.GameOperations.Queries.GetGame;
using game_store.DBOperations;
using game_store.Entities;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.GameOperations.Queries.GetGame {
	public class GetGameQueryTests : IClassFixture<CommonTestFixture> {
		private readonly GameStoreDbContext context;
		private readonly IMapper mapper;
		public GetGameQueryTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
			mapper = test_fixture.Mapper;
		}
		[Fact]
		public void WhenNotExistGameIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			GetGameQuery query = new GetGameQuery(context, mapper);
			query.GameID = 0;
			FluentActions
				.Invoking(() => query.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Game could not be found.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Game_ShouldBeReturn() {
			GetGameQuery query = new GetGameQuery(context, mapper);
			query.GameID = 1;
			FluentActions.Invoking(() => query.Handle()).Invoke();
			Game? game = context.Games.SingleOrDefault(g => g.ID == query.GameID);
			game.Should().NotBeNull();
		}
	}
}