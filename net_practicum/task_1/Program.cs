using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using task_1.Data;
namespace task_1 {
	public class Program {
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllers();
			builder.Services.AddDbContext<EmployeeDbContext>(options => options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["DbConnection"]));
			builder.Services.AddControllersWithViews().AddNewtonsoftJson();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			var app = builder.Build();
			if (app.Environment.IsDevelopment()) {
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseAuthorization();
			app.MapControllers();
			app.Run();
		}
	}
}