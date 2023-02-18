using FluentAssertions;
using movie_store.Application.ActorOperations.Commands.CreateActor;
using movie_store.Entities;
using xUnitTests.TestSetup;
using static movie_store.Application.ActorOperations.Commands.CreateActor.CreateActorCommand;
namespace xUnitTests.Application.ActorOperations.Commands.CreateActor {
	public class CreateActorCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData("", "")]
		[InlineData(" ", " ")]
		[InlineData("K", "R")]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(string name, string surname) {
			CreateActorCommand command = new CreateActorCommand(null, null);
			command.Model = new CreateActorModel() { Name = name, Surname = surname };
			CreateActorCommandValidator validator = new CreateActorCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError() {
			CreateActorCommand command = new CreateActorCommand(null, null);
			command.Model = new CreateActorModel() { Name = "Keanu", Surname = "Reeves" };
			CreateActorCommandValidator validator = new CreateActorCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}