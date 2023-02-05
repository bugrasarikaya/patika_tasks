using Microsoft.AspNetCore.JsonPatch;
using task_2.Models;
namespace task_2.Repository {
	public interface IEmployeeRepository {
		public ICollection<Employee> List();
		public ICollection<Employee>? ListByParameter(string orderby);
		public Employee? Get(int id);
		public Employee Create(Employee employee);
		public Employee? Delete(int id);
		public Employee? Update(int id, Employee employee);
		public Employee? Patch(int id, JsonPatchDocument<Employee> patch_employee);
	}
}