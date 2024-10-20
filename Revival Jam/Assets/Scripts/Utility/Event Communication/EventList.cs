namespace Utility.EventCommunication
{
	public static class EventList
	{
		public const string Empty = "Empty";

		public const string ShakeCamera = "ShakeCamera";

		public const string SetQuality = "SetQuality";

		public const string PlayerLose = "Player Lose";

		#region Audio
		public const string AudioPlayOneTime = "AudioPlayOneTime";
		public const string AudioPlayLoop = "AudioPlayLoop";
		public const string AudioPlayIntroLoop = "AudioPlayIntroLoop";
		public const string DestroyAudioHub = "DestroyAudioHub";
		public const string AudioStop = "AudioStop";
		public const string AudioMute = "AudioMute";
		#endregion

		#region Web Data
		public const string LoadUser = "LoadUser";
		public const string UserSuccess = "UserSuccess";
		public const string UserFailed = "UserFailed";

		public const string LoadProgress = "LoadProgress";
		public const string ProgressSuccess = "ProgressSuccess";
		public const string ProgressFailed = "ProgressFailed";

		public const string SaveProgress = "SaveProgress";
		public const string SaveSuccess = "SaveSuccess";
		public const string SaveFailed = "SaveFailed";

		public const string GetProgressValue = "GetProgressValue";
		public const string GetProgressValues = "GetProgressValues";
		public const string SendProgressValue = "SendProgressValue";
		public const string SendProgressValues = "SendProgressValues";
		public const string SetProgressValue = "SetProgressValue";
		public const string SetProgressValues = "SetProgressValues";
		#endregion
	}
}