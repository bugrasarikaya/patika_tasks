using System.Reflection;
using Microsoft.EntityFrameworkCore;
using movie_store.DBOperations;
using movie_store.Middlewares;
using movie_store.Services;
namespace movie_store {
	public class Program {
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbContext<MovieStoreDbContext>(options => options.UseInMemoryDatabase(databaseName: "MovieStoreDb"));
			builder.Services.AddScoped<IMovieStoreDbContext>(provider => provider.GetService<MovieStoreDbContext>()!);
			builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
			builder.Services.AddSingleton<ILoggerService, DbLogger>();
			var app = builder.Build();
			using (var scope = app.Services.CreateScope()) DataGenerator.Initialize(scope.ServiceProvider);
			app.UseSwagger();
			app.UseSwaggerUI();
			app.UseAuthorization();
			app.UseCustomExceptionMiddle();
			app.MapControllers();
			app.Run();
		}
	}
}