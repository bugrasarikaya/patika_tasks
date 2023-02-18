using AutoMapper;
using FluentAssertions;
using movie_store.Application.ActorOperations.Queries.GetActor;
using movie_store.DBOperations;
using movie_store.Entities;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.ActorOperations.Queries.GetActor {
	public class GetActorDetailQueryTests : IClassFixture<CommonTestFixture> {
		private readonly MovieStoreDbContext context;
		private readonly IMapper mapper;
		public GetActorDetailQueryTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
			mapper = test_fixture.Mapper;
		}
		[Fact]
		public void WhenNotExistActorIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			GetActorQuery query = new GetActorQuery(context, mapper);
			query.ActorID = 0;
			FluentActions
				.Invoking(() => query.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Actor could not be found.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Actor_ShouldBeReturn() {
			GetActorQuery query = new GetActorQuery(context, mapper);
			query.ActorID = 1;
			FluentActions.Invoking(() => query.Handle()).Invoke();
			Actor? actor = context.Actors.SingleOrDefault(a => a.ID == query.ActorID);
			actor.Should().NotBeNull();
		}
	}
}