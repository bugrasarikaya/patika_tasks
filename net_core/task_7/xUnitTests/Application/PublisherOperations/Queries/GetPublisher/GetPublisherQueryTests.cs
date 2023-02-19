using AutoMapper;
using FluentAssertions;
using game_store.Application.PublisherOperations.Queries.GetPublisher;
using game_store.DBOperations;
using game_store.Entities;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.PublisherOperations.Queries.GetPublisher {
	public class GetPublisherDetailQueryTests : IClassFixture<CommonTestFixture> {
		private readonly GameStoreDbContext context;
		private readonly IMapper mapper;
		public GetPublisherDetailQueryTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
			mapper = test_fixture.Mapper;
		}
		[Fact]
		public void WhenNotExistPublisherIDIsGiven_InvalidOperationException_ShouldBeReturn() {
			GetPublisherQuery query = new GetPublisherQuery(context, mapper);
			query.PublisherID = 0;
			FluentActions
				.Invoking(() => query.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Publisher could not be found.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Publisher_ShouldBeReturn() {
			GetPublisherQuery query = new GetPublisherQuery(context, mapper);
			query.PublisherID = 1;
			FluentActions.Invoking(() => query.Handle()).Invoke();
			Publisher? publisher = context.Publishers.SingleOrDefault(p => p.ID == query.PublisherID);
			publisher.Should().NotBeNull();
		}
	}
}