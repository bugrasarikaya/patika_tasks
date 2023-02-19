using FluentAssertions;
using game_store.Application.DeveloperOperations.Commands.UpdateDeveloper;
using xUnitTests.TestSetup;
using static game_store.Application.DeveloperOperations.Commands.UpdateDeveloper.UpdateDeveloperCommand;
namespace xUnitTests.Application.DeveloperOperations.Commands.UpdateDeveloper {
	public class UpdateDeveloperCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData("", 0)]
		[InlineData(" ", 0)]
		[InlineData("C", 1900)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(string name, int year) {
			UpdateDeveloperCommand command = new UpdateDeveloperCommand(null);
			command.Model = new UpdateDeveloperModel() { Name = name, Year = year };
			UpdateDeveloperCommandValidator validator = new UpdateDeveloperCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError() {
			UpdateDeveloperCommand command = new UpdateDeveloperCommand(null);
			command.DeveloperID = 1;
			command.Model = new UpdateDeveloperModel() { Name = "CD PROJEKT RED", Year = 1994 };
			UpdateDeveloperCommandValidator validator = new UpdateDeveloperCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}