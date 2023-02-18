using FluentAssertions;
using movie_store.Application.DirectorOperations.Commands.DeleteDirector;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.DirectorOperations.Commands.DeleteDirector {
	public class DeleteDirectorCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(int director_ID) {
			DeleteDirectorCommand command = new DeleteDirectorCommand(null);
			command.DirectorID = director_ID;
			DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError(int director_ID) {
			DeleteDirectorCommand command = new DeleteDirectorCommand(null);
			command.DirectorID = director_ID;
			DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}