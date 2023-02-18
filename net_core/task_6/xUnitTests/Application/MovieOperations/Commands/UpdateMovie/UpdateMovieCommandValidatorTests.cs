using FluentAssertions;
using movie_store.Application.MovieOperations.Commands.UpdateMovie;
using xUnitTests.TestSetup;
using static movie_store.Application.MovieOperations.Commands.UpdateMovie.UpdateMovieCommand;
namespace xUnitTests.Application.MovieOperations.Commands.UpdateMovie {
	public class UpdateMovieCommandValidatorTests : IClassFixture<CommonTestFixture> {
		public static IEnumerable<object[]> Data() {
			yield return new object[] { "", 0, 0.0, new List<int>(), new List<int>(), new List<int>() };
			yield return new object[] { " ", 0, 1.0, new List<int>(), new List<int>(), new List<int>() };
			yield return new object[] { " ", 1900, 1.0, new List<int>() { 1 }, new List<int>() { 1 }, new List<int>() { 1 } };
		}
		[Theory]
		[MemberData(nameof(Data))]
		public void WhenInvalidInputAreGiven_Validator_ShoudlBeReturnErrors(string name, int year, double price, List<int> list_actor_ID, List<int> list_director_ID, List<int> list_genre_ID) {
			UpdateMovieCommand command = new UpdateMovieCommand(null);
			command.Model = new UpdateMovieModel() { Name = name, Year = year, Price = price, ActorIDs = list_actor_ID, DirectorIDs = list_director_ID, GenreIDs = list_genre_ID };
			UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);
		}
		[Fact]
		public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError() {
			UpdateMovieCommand command = new UpdateMovieCommand(null);
			command.MovieID = 1;
			command.Model = new UpdateMovieModel() { Name = "Matrix", Year = 1999, Price = 17.99, ActorIDs = new List<int>() { 1 }, DirectorIDs = new List<int>() { 1 }, GenreIDs = new List<int>() { 1 } };
			UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().Be(0);
		}
	}
}