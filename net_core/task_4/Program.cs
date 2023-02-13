using Microsoft.EntityFrameworkCore;
using System.Reflection;
using task_4.DBOperations;
using task_4.Middlewares;
using task_4.Services;
namespace task_4 {
	public class Program {
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseInMemoryDatabase(databaseName: "BookStoreDB"));
			builder.Services.AddScoped<IBookStoreDbContext>(provider => provider.GetService<BookStoreDbContext>());
			builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
			builder.Services.AddSingleton<ILoggerService, DbLogger>();
			var app = builder.Build();
			using (var scope = app.Services.CreateScope()) {
				var services = scope.ServiceProvider;
				DataGenerator.Initialize(services);
			}
			if (app.Environment.IsDevelopment()) {
				app.UseSwagger();
				app.UseSwaggerUI();
				app.UseAuthorization();
				app.UseCustomExceptionMiddle();
				app.MapControllers();
				app.Run();
			}
		}
	}
}