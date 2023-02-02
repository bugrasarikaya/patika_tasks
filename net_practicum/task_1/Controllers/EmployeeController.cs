using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using task_1.Data;
using task_1.Models;
namespace task_1.Controllers {
	[ApiController]
	[Route("api/[controller]")]
	public class EmployeeController : ControllerBase {
		private readonly ILogger<EmployeeController> logger;
		private readonly EmployeeDbContext context;
		public EmployeeController(ILogger<EmployeeController> logger, EmployeeDbContext context) {
			this.logger = logger;
			this.context = context;
		}
		[HttpGet]
		public IActionResult ListEmployees() { // Listing all employees.
			try {
				return Ok(context.Employees.ToList());
			} catch (Exception) {
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
		[HttpGet]
		[Route("{orderby}")]
		public IActionResult ListEmployeesByName(string orderby) { // Listing all employees with ordering by given argument.
			if (string.IsNullOrEmpty(orderby)) return BadRequest();
			try {
				if (string.Equals(orderby, "name", StringComparison.OrdinalIgnoreCase)) return Ok(context.Employees.OrderBy(e => e.Name).ToList());
				else if (string.Equals(orderby, "surname", StringComparison.OrdinalIgnoreCase)) return Ok(context.Employees.OrderBy(e => e.Surname).ToList());
				else if (string.Equals(orderby, "phone", StringComparison.OrdinalIgnoreCase)) return Ok(context.Employees.OrderBy(e => e.Phone).ToList());
				else if (string.Equals(orderby, "department", StringComparison.OrdinalIgnoreCase)) return Ok(context.Employees.OrderBy(e => e.Department).ToList());
				else return BadRequest();
			} catch (Exception) {
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
		[HttpGet]
		[Route("{id:int}")]
		public IActionResult GetEmployee(int id) { // Getting an employee.
			if (id == 0) return BadRequest();
			try {
				var result = context.Employees.SingleOrDefault(e => e.ID == id);
				if (result == null) return NotFound();
				else return Ok(result);
			} catch (Exception) {
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
		[HttpPost]
		public IActionResult CreateEmployee(Employee employee) { // Creating an employee.
			if (employee == null) return BadRequest();
			try {
				context.Add(employee);
				context.SaveChanges();
				return Created("api/Employee/" + employee.ID, employee);
			} catch (Exception) {
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
		[HttpDelete]
		[Route("{id:int}")]
		public IActionResult DeleteEmployee(int id) { // Deleting an employee.
			if (id == 0) return BadRequest();
			try {
				var result = context.Employees.SingleOrDefault(e => e.ID == id);
				if (result == null) return NotFound();
				else {
					context.Employees.Remove(result);
					context.SaveChanges();
					return NoContent();
				}
			} catch (Exception) {
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
		[HttpPut]
		public IActionResult UpdateEmployee(int id, [FromBody] Employee employee) { // Updating an employe.
			if (id == 0 || employee == null) return BadRequest();
			try {
				var result = context.Employees.SingleOrDefault(e => e.ID == id);
				if (result == null) return NotFound();
				else {
					result.Name = employee.Name;
					result.Surname = employee.Surname;
					result.Phone = employee.Phone;
					result.Department = employee.Department;
					context.SaveChanges();
					return Ok(result);
				}
			} catch (Exception) {
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
		[HttpPatch]
		[Route("{id:int}")]
		public IActionResult PatchEmployee(int id, [FromBody] JsonPatchDocument<Employee> patch_employee) { // Updating an employe partially. 
			if (id == 0 || patch_employee == null) return BadRequest();
			try {
				var result = context.Employees.SingleOrDefault(e => e.ID == id);
				if (result == null) return NotFound();
				else {
					patch_employee.ApplyTo(result);
					return Ok(result);
				}
			} catch (Exception) {
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
	}
}