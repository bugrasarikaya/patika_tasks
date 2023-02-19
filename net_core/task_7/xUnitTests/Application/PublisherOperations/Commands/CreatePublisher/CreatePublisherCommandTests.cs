using AutoMapper;
using FluentAssertions;
using game_store.Application.PublisherOperations.Commands.CreatePublisher;
using game_store.DBOperations;
using game_store.Entities;
using xUnitTests.TestSetup;
using static game_store.Application.PublisherOperations.Commands.CreatePublisher.CreatePublisherCommand;
namespace xUnitTests.Application.PublisherOperations.Commands.CreatePublisher {
	public class CreatePublisherCommandTests : IClassFixture<CommonTestFixture> {
		private readonly GameStoreDbContext context;
		private readonly IMapper mapper;
		public CreatePublisherCommandTests(CommonTestFixture test_fixture) {
			context = test_fixture.Context;
			mapper = test_fixture.Mapper;
		}
		[Fact]
		public void WhenAlreadyExistPublisherIsGiven_InvalidOperationException_ShouldBeReturn() {
			Publisher publisher = new Publisher() { Name = "CD PROJEKT RED", Year = 1994 };
			context.Publishers.Add(publisher);
			context.SaveChanges();
			CreatePublisherCommand command = new CreatePublisherCommand(context, mapper);
			command.Model = new CreatePublisherModel() { Name = publisher.Name, Year = publisher.Year };
			FluentActions
				.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Publisher already exists.");
		}
		[Fact]
		public void WhenValidInputAreGiven_Publisher_ShouldBeCreated() {
			CreatePublisherCommand command = new CreatePublisherCommand(context, mapper);
			CreatePublisherModel model = new CreatePublisherModel() { Name = "CD PROJEKT RED", Year = 1994 };
			command.Model = model;
			FluentActions.Invoking(() => command.Handle()).Invoke();
			Publisher? publisher = context.Publishers.FirstOrDefault(p => p.Name == model.Name && p.Year == model.Year);
			publisher.Should().NotBeNull();
			publisher?.Name.Should().Be(model.Name);
			publisher?.Year.Should().Be(model.Year);
		}
	}
}