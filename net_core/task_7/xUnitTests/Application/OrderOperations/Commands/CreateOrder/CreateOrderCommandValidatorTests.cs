using FluentAssertions;
using game_store.Application.OrderOperations.Commands.CreateOrder;
using xUnitTests.TestSetup;
using static game_store.Application.OrderOperations.Commands.CreateOrder.CreateOrderCommand;
namespace xUnitTests.Application.OrderOperations.Commands.CreateOrder {
	public class CreateOrderCommandValidatorTests : IClassFixture<CommonTestFixture> {
		public static IEnumerable<object[]> Data() {
			yield return new object[] { 0, new List<int>() };
			yield return new object[] { -1, new List<int>() };
		}
		[Theory]
		[MemberData(nameof(Data))]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(int customer_id, List<int> list_game_ID) {
			CreateOrderCommand command = new CreateOrderCommand(null);
			command.Model = new CreateOrderModel() { CustomerID = customer_id, GameIDs = list_game_ID };
			CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError() {
			CreateOrderCommand command = new CreateOrderCommand(null);
			command.Model = new CreateOrderModel() { CustomerID = 1, GameIDs = new List<int>() { 1 } };
			CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}