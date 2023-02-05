using task_2.CustomAttributes;
namespace task_2.CustomMiddlewares {
	public class AuthenticationMiddleware {
		private readonly ILogger logger;
		private readonly RequestDelegate next;
		private readonly string account_role = "Admin"; // Static account role for implementing a fake authentication service.
		public AuthenticationMiddleware(ILoggerFactory logger_factory, RequestDelegate next) {
			this.next = next;
			logger = logger_factory.CreateLogger<AuthenticationMiddleware>();
		}
		public async Task Invoke(HttpContext context) { // Checking account role for login.
			string account_attribute = context.GetEndpoint()!.Metadata.GetMetadata<AccountAttribute>()!.GetRole();
			if (string.Equals(account_role, account_attribute)) {
				logger.LogInformation(account_attribute + " logged into system.");
				await next(context);
			} else { // Returning 403 HTTP status code if account is not authorized.
				var response = context.Response;
				logger.LogWarning("An unauthorized user attempted to log into system.");
				response.StatusCode = StatusCodes.Status403Forbidden;
				await response.StartAsync();
			}
		}
	}
}