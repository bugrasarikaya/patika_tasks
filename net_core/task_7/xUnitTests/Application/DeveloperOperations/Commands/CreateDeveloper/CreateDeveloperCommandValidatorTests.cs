using FluentAssertions;
using game_store.Application.DeveloperOperations.Commands.CreateDeveloper;
using xUnitTests.TestSetup;
using static game_store.Application.DeveloperOperations.Commands.CreateDeveloper.CreateDeveloperCommand;
namespace xUnitTests.Application.DeveloperOperations.Commands.CreateDeveloper {
	public class CreateDeveloperCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData("", 0)]
		[InlineData(" ", 0)]
		[InlineData("C", 1900)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(string name, int year) {
			CreateDeveloperCommand command = new CreateDeveloperCommand(null, null);
			command.Model = new CreateDeveloperModel() { Name = name, Year = year };
			CreateDeveloperCommandValidator validator = new CreateDeveloperCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError() {
			CreateDeveloperCommand command = new CreateDeveloperCommand(null, null);
			command.Model = new CreateDeveloperModel() { Name = "CD PROJEKT RED", Year = 1994 };
			CreateDeveloperCommandValidator validator = new CreateDeveloperCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}