namespace Utility.EventCommunication
{
	public class EventData
	{
		public readonly object eventInformation;
		public static readonly EventData empty = new EventData(null);

		public EventData(object information)
		{ eventInformation = information; }
	}
}