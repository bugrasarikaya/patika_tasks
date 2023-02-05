namespace task_2.ExtensionMethods {
	public static class ConverterString {
		public static string ToUpperFirstLetter(this string word) { // Converting first letter to uppercase and the rest to lowercase.
			return word.Length == 1 ? word.ToUpper() : char.ToUpper(word[0]) + word.Substring(1).ToLower();
		}
	}
}