using FluentAssertions;
using game_store.Application.CustomerOperations.Commands.CreateCustomer;
using xUnitTests.TestSetup;
using static game_store.Application.CustomerOperations.Commands.CreateCustomer.CreateCustomerCommand;
namespace xUnitTests.Application.CustomerOperations.Commands.CreateGame {
	public class CreateCustomerCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData("", "")]
		[InlineData(" ", " ")]
		[InlineData("theresv", "1234567")]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(string email, string password) {
			CreateCustomerCommand command = new CreateCustomerCommand(null, null);
			command.Model = new CreateCustomerModel() { Email = email, Password = password };
			CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError() {
			CreateCustomerCommand command = new CreateCustomerCommand(null, null);
			command.Model = new CreateCustomerModel() { Email = "theresevoerman@schrecknet.vtm", Password = "12345678" };
			CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}