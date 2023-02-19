using FluentAssertions;
using game_store.Application.PublisherOperations.Commands.DeletePublisher;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.PublisherOperations.Commands.DeletePublisher {
	public class DeletePublisherCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(int publisher_ID) {
			DeletePublisherCommand command = new DeletePublisherCommand(null);
			command.PublisherID = publisher_ID;
			DeletePublisherCommandValidator validator = new DeletePublisherCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError(int publisher_ID) {
			DeletePublisherCommand command = new DeletePublisherCommand(null);
			command.PublisherID = publisher_ID;
			DeletePublisherCommandValidator validator = new DeletePublisherCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}