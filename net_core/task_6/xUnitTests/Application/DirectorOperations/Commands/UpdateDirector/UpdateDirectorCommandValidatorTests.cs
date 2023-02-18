using FluentAssertions;
using movie_store.Application.DirectorOperations.Commands.UpdateDirector;
using xUnitTests.TestSetup;
using static movie_store.Application.DirectorOperations.Commands.UpdateDirector.UpdateDirectorCommand;
namespace xUnitTests.Application.DirectorOperations.Commands.UpdateDirector {
	public class UpdateDirectorCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData("", "")]
		[InlineData(" ", " ")]
		[InlineData("L", "W")]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(string name, string surname) {
			UpdateDirectorCommand command = new UpdateDirectorCommand(null);
			command.Model = new UpdateDirectorModel() { Name = name, Surname = surname };
			UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError() {
			UpdateDirectorCommand command = new UpdateDirectorCommand(null);
			command.DirectorID = 1;
			command.Model = new UpdateDirectorModel() { Name = "Lana", Surname = "Wachowski" };
			UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}