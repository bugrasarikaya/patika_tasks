namespace task_2.CustomMiddlewares {
	public class ExceptionMiddleware {
		private readonly RequestDelegate next;
		private readonly ILogger logger;
		public ExceptionMiddleware(ILoggerFactory logger_factory, RequestDelegate next) {
			this.next = next;
			logger = logger_factory.CreateLogger<ExceptionMiddleware>();
		}
		public async Task Invoke(HttpContext context) { // Handling exception.
			try {
				await next(context);
			} catch (Exception) { // Returning 500 HTTP status code if an exception occurs.
				var response = context.Response;
				logger.LogError("An error occurred.");
				response.StatusCode = StatusCodes.Status500InternalServerError;
				await response.StartAsync();
			}
		}
	}
}