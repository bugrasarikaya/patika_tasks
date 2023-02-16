using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using movie_store.DBOperations;
using movie_store.Middlewares;
using movie_store.Services;
namespace movie_store {
	public class Program {
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);
			ConfigurationManager configuration = builder.Configuration;
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			//builder.Services.AddSwaggerGen();
			builder.Services.AddSwaggerGen(options => {
				options.SwaggerDoc("v1", new OpenApiInfo { Title = "movie_store", Version = "v1" });
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
			builder.Services.AddDbContext<MovieStoreDbContext>(options => options.UseInMemoryDatabase(databaseName: "MovieStoreDb").EnableSensitiveDataLogging(true));
			builder.Services.AddScoped<IMovieStoreDbContext>(provider => provider.GetService<MovieStoreDbContext>()!);
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
			app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "movie_store"); });
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseCustomExceptionMiddle();
			app.MapControllers();
			app.Run();
		}
	}
}