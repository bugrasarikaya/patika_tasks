using FluentAssertions;
using movie_store.Application.DirectorOperations.Commands.CreateDirector;
using xUnitTests.TestSetup;
using static movie_store.Application.DirectorOperations.Commands.CreateDirector.CreateDirectorCommand;
namespace xUnitTests.Application.DirectorOperations.Commands.CreateDirector {
	public class CreateDirectorCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData("", "")]
		[InlineData(" ", " ")]
		[InlineData("L", "W")]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(string name, string surname) {
			CreateDirectorCommand command = new CreateDirectorCommand(null, null);
			command.Model = new CreateDirectorModel() { Name = name, Surname = surname };
			CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError() {
			CreateDirectorCommand command = new CreateDirectorCommand(null, null);
			command.Model = new CreateDirectorModel() { Name = "Lana", Surname = "Wachowski" };
			CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}