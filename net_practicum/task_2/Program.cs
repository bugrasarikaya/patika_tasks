using Microsoft.EntityFrameworkCore;
using task_2.CustomMiddlewares;
using task_2.Data;
using task_2.Repository;
namespace task_2 {
	public class Program {
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllers();
			builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
			builder.Services.AddDbContext<EmployeeDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
			builder.Services.AddControllersWithViews().AddNewtonsoftJson();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			var app = builder.Build();
			if (app.Environment.IsDevelopment()) {
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseAuthorization();
			app.UseMiddleware<ExceptionMiddleware>();
			app.UseMiddleware<AuthenticationMiddleware>();
			app.UseMiddleware<LoggingMiddleware>();
			app.MapControllers();
			app.Run();
		}
	}
}