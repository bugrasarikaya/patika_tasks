using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using task_2.CustomAttributes;
using task_2.Models;
using task_2.Repository;
namespace task_1.Controllers {
	[ApiController]
	[Account("Admin")]
	[Route("api/[controller]")]
	public class EmployeeController : ControllerBase {
		private readonly IEmployeeRepository EmployeeRepository;
		public EmployeeController(IEmployeeRepository EmployeeRepository) {
			this.EmployeeRepository = EmployeeRepository;
		}
		[HttpGet]
		public IActionResult ListEmployees() { // Responding with employee list after providing.
			return Ok(EmployeeRepository.List());
		}
		[HttpGet]
		[Route("{orderby}")]
		public IActionResult ListEmployeesByParameter(string orderby) { // Responding with employee list by given argument after providing.
			if (string.IsNullOrEmpty(orderby)) return BadRequest();
			ICollection<Employee>? collection_employee = EmployeeRepository.ListByParameter(orderby);
			if (collection_employee == null) return BadRequest();
			else return Ok(collection_employee);
		}
		[HttpGet]
		[Route("{id:int}")]
		public IActionResult GetEmployee(int id) { // Responding with an employee after providing.
			if (id <= 0) return BadRequest();
			Employee? employee = EmployeeRepository.Get(id);
			if (employee == null) return NotFound();
			else return Ok(employee);
		}
		[HttpPost]
		public IActionResult CreateEmployee(Employee employee) { // Responding with a created employee after creating.
			if (employee == null) return BadRequest();
			EmployeeRepository.Create(employee);
			return Created("api/Employee/" + employee.ID, employee);
		}
		[HttpDelete]
		[Route("{id:int}")]
		public IActionResult DeleteEmployee(int id) { // Responding with no content after deleting.
			if (id <= 0) return BadRequest();
			Employee? employee = EmployeeRepository.Delete(id);
			if (employee == null) return NotFound();
			else return NoContent();
		}
		[HttpPut]
		public IActionResult UpdateEmployee(int id, [FromBody] Employee employee) { // Responding with an updated employee after updating.
			if (id <= 0 || employee == null) return BadRequest();
			Employee? employee_curent = EmployeeRepository.Update(id, employee);
			if (employee_curent == null) return NotFound();
			else return Ok(employee_curent);
		}
		[HttpPatch]
		[Route("{id:int}")]
		public IActionResult PatchEmployee(int id, [FromBody] JsonPatchDocument<Employee> patch_employee) { // Responding with a partially updated employee after patching.
			if (id <= 0 || patch_employee == null) return BadRequest();
			Employee? employee_curent = EmployeeRepository.Patch(id, patch_employee);
			if (employee_curent == null) return NotFound();
			else return Ok(employee_curent);
		}
	}
}