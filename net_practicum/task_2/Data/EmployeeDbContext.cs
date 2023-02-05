using Microsoft.EntityFrameworkCore;
using task_2.Data.Configurations;
using task_2.Models;
namespace task_2.Data {
	public class EmployeeDbContext : DbContext {
		public DbSet<Employee> Employees { get; set; }
		public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }
		protected override void OnModelCreating(ModelBuilder model_builder) {
			model_builder.ApplyConfiguration(new EmployeeConfiguration());
		}
	}
}