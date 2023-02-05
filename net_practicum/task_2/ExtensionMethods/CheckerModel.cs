using Microsoft.EntityFrameworkCore;
using task_2.Models;
namespace task_2.ExtensionMethods {
	public static class CheckerModel {
		public static bool CheckPropertyName(this DbContext context, string parameter_column) { // Checking column name with given argument.
			bool result = false;
			foreach (string name_column in context.Model.FindEntityType(typeof(Employee))!.GetProperties().Select(p => p.Name)) {
				if (string.Equals(parameter_column.ToUpperFirstLetter(), name_column)) {
					result = true;
					break;
				}
			}
			return result;
		}
	}
}