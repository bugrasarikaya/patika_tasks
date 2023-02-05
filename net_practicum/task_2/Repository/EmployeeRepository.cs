using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using task_2.Data;
using task_2.Models;
using task_2.ExtensionMethods;
namespace task_2.Repository {
	public class EmployeeRepository : IEmployeeRepository {
		private readonly EmployeeDbContext context;
		public EmployeeRepository(EmployeeDbContext context) {
			this.context = context;
		}
		public ICollection<Employee> List() { // Listing all employees.
			return context.Employees.ToList();
		}
		public ICollection<Employee>? ListByParameter(string orderby) { // Listing all employees with ordering by given argument.
			if (!context.CheckPropertyName(orderby)) return null;
			ICollection<Employee> collection_employee = context.Employees.OrderBy(e => EF.Property<object>(e, orderby.ToUpperFirstLetter())).ToList();
			return collection_employee;
		}
		public Employee? Get(int id) { // Getting an employee.
			return context.Employees.SingleOrDefault(e => e.ID == id);
		}
		public Employee Create(Employee employee) { // Creating an employee.
			context.Add(employee);
			context.SaveChanges();
			return employee;
		}
		public Employee? Delete(int id) { // Deleting an employee.
			Employee? result = context.Employees.SingleOrDefault(e => e.ID == id);
			if (result != null) {
				context.Employees.Remove(result);
				context.SaveChanges();
			}
			return result;
		}
		public Employee? Update(int id, Employee employee) {  // Updating an employee.
			Employee? employee_current = context.Employees.SingleOrDefault(e => e.ID == id);
			if (employee_current != null) {
				employee_current.Name = employee.Name;
				employee_current.Surname = employee.Surname;
				employee_current.Phone = employee.Phone;
				employee_current.Department = employee.Department;
				context.SaveChanges();
			}
			return employee_current;
		}
		public Employee? Patch(int id, JsonPatchDocument<Employee> patch_employee) { // Updating an employee partially.
			Employee? employee_current = context.Employees.SingleOrDefault(e => e.ID == id);
			if (employee_current != null) patch_employee.ApplyTo(employee_current);
			return employee_current;
		}
	}
}