using FluentAssertions;
using movie_store.Application.CustomerOperations.Commands.DeleteCustomer;
using xUnitTests.TestSetup;
namespace xUnitTests.Application.CustomerOperations.Commands.DeleteCustomer {
	public class DeleteCustomerCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(int customer_ID) {
			DeleteCustomerCommand command = new DeleteCustomerCommand(null);
			command.CustomerID = customer_ID;
			DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError(int customer_ID) {
			DeleteCustomerCommand command = new DeleteCustomerCommand(null);
			command.CustomerID = customer_ID;
			DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}