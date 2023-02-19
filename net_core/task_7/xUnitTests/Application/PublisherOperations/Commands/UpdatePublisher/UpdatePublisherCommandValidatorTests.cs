using FluentAssertions;
using game_store.Application.PublisherOperations.Commands.UpdatePublisher;
using xUnitTests.TestSetup;
using static game_store.Application.PublisherOperations.Commands.UpdatePublisher.UpdatePublisherCommand;
namespace xUnitTests.Application.PublisherOperations.Commands.UpdatePublisher {
	public class UpdatePublisherCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData("", 0)]
		[InlineData(" ", 0)]
		[InlineData("C", 1900)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(string name, int year) {
			UpdatePublisherCommand command = new UpdatePublisherCommand(null);
			command.Model = new UpdatePublisherModel() { Name = name, Year = year };
			UpdatePublisherCommandValidator validator = new UpdatePublisherCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError() {
			UpdatePublisherCommand command = new UpdatePublisherCommand(null);
			command.PublisherID = 1;
			command.Model = new UpdatePublisherModel() { Name = "CD PROJEKT RED", Year = 1994 };
			UpdatePublisherCommandValidator validator = new UpdatePublisherCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}