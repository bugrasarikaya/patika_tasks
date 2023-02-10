namespace task_4.Services {
	public class DbLogger : ILoggerService {
		public void Write(string message) {
			Console.WriteLine("[DbLogger] - " + message);
		}
	}
}