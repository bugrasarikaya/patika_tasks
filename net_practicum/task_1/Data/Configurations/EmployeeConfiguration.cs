using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using task_1.Models;
namespace task_1.Data.Configurations {
	public class EmployeeConfiguration : IEntityTypeConfiguration<Employee> {
		public void Configure(EntityTypeBuilder<Employee> builder) {
			builder.ToTable("Employees");
			builder.HasKey(e => e.ID);
			builder.Property(e => e.Name).IsRequired(true).HasMaxLength(100).HasColumnType("varchar");
			builder.Property(e => e.Surname).IsRequired(true).HasMaxLength(100).HasColumnType("varchar");
			builder.Property(e => e.Phone).IsRequired(true).HasMaxLength(100).HasColumnType("varchar");
			builder.Property(e => e.Department).IsRequired(true).HasMaxLength(100).HasColumnType("varchar");
		}
	}
}