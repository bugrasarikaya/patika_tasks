using FluentAssertions;
using movie_store.Application.CustomerOperations.Commands.CreateCustomer;
using xUnitTests.TestSetup;
using static movie_store.Application.CustomerOperations.Commands.CreateCustomer.CreateCustomerCommand;
namespace xUnitTests.Application.CustomerOperations.Commands.CreateMovie {
	public class CreateCustomerCommandValidatorTests : IClassFixture<CommonTestFixture> {
		[Theory]
		[InlineData("", "", "", "")]
		[InlineData(" ", " ", " ", " ")]
		[InlineData("T", "V", "theresv", "1234567") ]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(string name, string surname, string email, string password) {
			CreateCustomerCommand command = new CreateCustomerCommand(null, null);
			command.Model = new CreateCustomerModel() { Name = name, Surname = surname, Email = email, Password = password };
			CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError() {
			CreateCustomerCommand command = new CreateCustomerCommand(null, null);
			command.Model = new CreateCustomerModel() { Name = "Therese", Surname = "Voerman", Email = "theresevoerman@schrecknet.vtm", Password = "12345678" };
			CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}