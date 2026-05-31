namespace Assignment_No._04_VP_LAB.Application_06
{
    public class NotificationService
    {
		private readonly NotificationConfig _globalConfiguration;

		// Add a field to store logs that can change
		private List<string> _internalLogStore = new();

		public NotificationService(NotificationConfig configuration)
		{
			_globalConfiguration = configuration;
		}

		public Task<List<string>> ExtractActiveSystemLogsAsync()
		{
			// Create a fresh list with a timestamp to prove it's refreshing
			var outputContainer = new List<string>
			{
				$"System Time: {DateTime.Now:HH:mm:ss} - Decoupled profiles loaded.",
				"Log 02: Dependency life cycle established via Scoped container."
			};

			for (int i = 1; i <= _globalConfiguration.DefaultNumberOfNotifications; i++)
			{
				outputContainer.Add($"[Registry Frame 0{i}]: Metrics mapping active.");
			}

			return Task.FromResult(outputContainer);
		}
	}
}
