using FluentAssertions;
using movie_store.Application.ActorOperations.Commands.DeleteActor;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.ActorOperations.Commands.DeleteActor {
	public class DeleteActorCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(int actor_ID) {
			DeleteActorCommand command = new DeleteActorCommand(null);
			command.ActorID = actor_ID;
			DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError(int actor_ID) {
			DeleteActorCommand command = new DeleteActorCommand(null);
			command.ActorID = actor_ID;
			DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}