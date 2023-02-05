using System.ComponentModel.DataAnnotations;
namespace task_2.Models {
	public class Employee {
		public int ID;
		[StringLength(100)]
		public string Name { get; set; } = null!;
		[StringLength(100)]
		public string Surname { get; set; } = null!;
		[StringLength(100)]
		public string Phone { get; set; } = null!;
		[StringLength(100)]
		public string Department { get; set; } = null!;
	}
}