﻿namespace movie_store.Services {
	public class ConsoleLogger : ILoggerService {
		public void Write(string message) {
			Console.WriteLine("[ConsoleLogger] - " + message);
		}
	}
}