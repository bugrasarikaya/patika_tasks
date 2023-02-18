using FluentAssertions;
using movie_store.Application.CustomerOperations.Commands.UpdateCustomer;
using xUnitTests.TestSetup;
using static movie_store.Application.CustomerOperations.Commands.UpdateCustomer.UpdateCustomerCommand;
namespace xUnitTests.Application.CustomerOperations.Commands.UpdateCustomer {
	public class UpdateCustomerCommandValidatorTests : IClassFixture<CommonTestFixture> {
		public static IEnumerable<object[]> Data() {
			yield return new object[] { "", "", "", "", new List<int>() };
			yield return new object[] { " ", " ", " ", " ", new List<int>() };
			yield return new object[] { "T", "V", "theresv", "1234567", new List<int>() { 1 } };
		}
		[Theory]
		[MemberData(nameof(Data))]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(string name, string surname, string email, string password, List<int> list_genre_ID) {
			UpdateCustomerCommand command = new UpdateCustomerCommand(null);
			command.Model = new UpdateCustomerModel() { Name = name, Surname = surname, Email = email, Password = password, GenreIDs = list_genre_ID };
			UpdateCustomerCommandValidator validator = new UpdateCustomerCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError() {
			UpdateCustomerCommand command = new UpdateCustomerCommand(null);
			command.CustomerID = 1;
			command.Model = new UpdateCustomerModel() { Name = "Therese", Surname = "Voerman", Email = "theresevoerman@schrecknet.vtm", Password = "12345678", GenreIDs = new List<int>() { 1 } };
			UpdateCustomerCommandValidator validator = new UpdateCustomerCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}