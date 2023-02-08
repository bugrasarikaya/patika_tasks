using Microsoft.EntityFrameworkCore;
using System.Reflection;
using task_3.DBOperations;
namespace task_3 {
	public class Program {
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseInMemoryDatabase(databaseName: "BookStoreDB"));
			builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
			var app = builder.Build();
			using (var scope = app.Services.CreateScope()) {
				var services = scope.ServiceProvider;
				DataGenerator.Initialize(services);
			}
			if (app.Environment.IsDevelopment()) {
				app.UseSwagger();
				app.UseSwaggerUI();
				app.UseAuthorization();
				app.MapControllers();
				app.Run();
			}
		}
	}
}