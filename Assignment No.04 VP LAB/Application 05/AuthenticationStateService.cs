namespace Assignment_No._04_VP_LAB.Application_05
{
    public class AuthenticationStateService
    {
		public event Action? OnStateChangedPipeline;
		public bool IsAuthenticated { get; private set; } = false;
		public string ActiveAccountHandle { get; private set; } = string.Empty;

		public void RunSecureLoginHandshake(string operatorUser)
		{
			IsAuthenticated = true;
			ActiveAccountHandle = operatorUser;
			TriggerStateBroadcast();
		}

		public void DestroyActiveSessionContext()
		{
			IsAuthenticated = false;
			ActiveAccountHandle = string.Empty;
			TriggerStateBroadcast();
		}

		private void TriggerStateBroadcast() => OnStateChangedPipeline?.Invoke();
	}
}
