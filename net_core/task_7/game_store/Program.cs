using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using game_store.DBOperations;
using game_store.Middlewares;
using game_store.Services;
namespace game_store {
	public class Program {
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);
			ConfigurationManager configuration = builder.Configuration;
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen(options => {
				options.SwaggerDoc("v1", new OpenApiInfo { Title = "game_store", Version = "v1" });
				options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
					Name = "Authorization",
					Description = "Please enter a valid token",
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
				});
				options.AddSecurityRequirement(new OpenApiSecurityRequirement {
					{ new OpenApiSecurityScheme {
						Reference = new OpenApiReference {
							Type = ReferenceType.SecurityScheme,
							Id ="Bearer"
						}
					},
					new string[] {}
					}
				});
			});
			builder.Services.AddDbContext<GameStoreDbContext>(options => options.UseInMemoryDatabase(databaseName: "GameStoreDb").EnableSensitiveDataLogging(true));
			builder.Services.AddScoped<IGameStoreDbContext>(provider => provider.GetService<GameStoreDbContext>()!);
			builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
			builder.Services.AddSingleton<ILoggerService, DbLogger>();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
				options.TokenValidationParameters = new TokenValidationParameters {
					ValidateAudience = true,
					ValidateIssuer = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = configuration["Token:Issuer"],
					ValidAudience = configuration["Token:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"])),
					ClockSkew = TimeSpan.Zero
				};
			});
			var app = builder.Build();
			using (var scope = app.Services.CreateScope()) DataGenerator.Initialize(scope.ServiceProvider);
			app.UseSwagger();
			app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "game_store"); });
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseCustomExceptionMiddle();
			app.MapControllers();
			app.Run();
		}
	}
}