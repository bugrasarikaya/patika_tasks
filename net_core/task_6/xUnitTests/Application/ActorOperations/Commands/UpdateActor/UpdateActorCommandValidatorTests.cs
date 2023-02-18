using FluentAssertions;
using movie_store.Application.ActorOperations.Commands.UpdateActor;
using xUnitTests.TestSetup;
using static movie_store.Application.ActorOperations.Commands.UpdateActor.UpdateActorCommand;
namespace xUnitTests.Application.ActorOperations.Commands.UpdateActor {
	public class UpdateActorCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData("", "")]
		[InlineData(" ", " ")]
		[InlineData("K", "R")]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(string name, string surname) {
			UpdateActorCommand command = new UpdateActorCommand(null);
			command.Model = new UpdateActorModel() { Name = name, Surname = surname };
			UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError() {
			UpdateActorCommand command = new UpdateActorCommand(null);
			command.ActorID = 1;
			command.Model = new UpdateActorModel() { Name = "Keanu", Surname = "Reeves" };
			UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}