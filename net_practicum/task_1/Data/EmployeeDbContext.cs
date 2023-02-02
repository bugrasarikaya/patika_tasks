using Microsoft.EntityFrameworkCore;
using task_1.Data.Configurations;
using task_1.Models;
namespace task_1.Data {
	public class EmployeeDbContext : DbContext {
		public DbSet<Employee> Employees { get; set; }
		public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }
		protected override void OnModelCreating(ModelBuilder model_builder) {
			model_builder.ApplyConfiguration(new EmployeeConfiguration());
		}
	}
}