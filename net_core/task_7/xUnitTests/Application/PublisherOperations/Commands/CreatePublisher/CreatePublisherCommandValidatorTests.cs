using FluentAssertions;
using game_store.Application.PublisherOperations.Commands.CreatePublisher;
using xUnitTests.TestSetup;
using static game_store.Application.PublisherOperations.Commands.CreatePublisher.CreatePublisherCommand;
namespace xUnitTests.Application.PublisherOperations.Commands.CreatePublisher {
	public class CreatePublisherCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData("", 0)]
		[InlineData(" ", 0)]
		[InlineData("C", 1900)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(string name, int year) {
			CreatePublisherCommand command = new CreatePublisherCommand(null, null);
			command.Model = new CreatePublisherModel() { Name = name, Year = year };
			CreatePublisherCommandValidator validator = new CreatePublisherCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError() {
			CreatePublisherCommand command = new CreatePublisherCommand(null, null);
			command.Model = new CreatePublisherModel() { Name = "CD PROJEKT RED", Year = 1994 };
			CreatePublisherCommandValidator validator = new CreatePublisherCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}