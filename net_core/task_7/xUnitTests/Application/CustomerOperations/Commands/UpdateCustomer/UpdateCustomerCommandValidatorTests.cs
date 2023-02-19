using FluentAssertions;
using game_store.Application.CustomerOperations.Commands.UpdateCustomer;
using xUnitTests.TestSetup;
using static game_store.Application.CustomerOperations.Commands.UpdateCustomer.UpdateCustomerCommand;
namespace xUnitTests.Application.CustomerOperations.Commands.UpdateCustomer {
	public class UpdateCustomerCommandValidatorTests : IClassFixture<CommonTestFixture> {
		public static IEnumerable<object[]> Data() {
			yield return new object[] { "", "" };
			yield return new object[] { " ", " " };
			yield return new object[] { "theresv", "1234567" };
		}
		[Theory]
		[MemberData(nameof(Data))]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(string email, string password) {
			UpdateCustomerCommand command = new UpdateCustomerCommand(null);
			command.Model = new UpdateCustomerModel() { Email = email, Password = password };
			UpdateCustomerCommandValidator validator = new UpdateCustomerCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError() {
			UpdateCustomerCommand command = new UpdateCustomerCommand(null);
			command.CustomerID = 1;
			command.Model = new UpdateCustomerModel() { Email = "theresevoerman@schrecknet.vtm", Password = "12345678" };
			UpdateCustomerCommandValidator validator = new UpdateCustomerCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}