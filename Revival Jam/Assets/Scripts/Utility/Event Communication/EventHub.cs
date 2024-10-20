using System.Collections.Generic;

namespace Utility.EventCommunication
{
	/// <summary>
	/// Static class to handle Pub/Sub Pattern
	/// </summary>
	public static class EventHub
	{
		public delegate void SubscriberReaction(EventData data);

		/// <summary>
		/// Match an event list's entry with a list of subscribers' reaction
		/// </summary>
		private static Dictionary<string, SubscriberReaction> reactions =
			new Dictionary<string, SubscriberReaction>();

		public static void Subscribe(string eventName, SubscriberReaction reaction)
		{
			if (string.IsNullOrEmpty(eventName))
			{ PrintConsole.Error("Empty event name"); return; }
			if (reaction == null)
			{ PrintConsole.Error("Null reaction to '" + eventName + "' event"); return; }

			if (!reactions.ContainsKey(eventName))
			{ reactions.Add(eventName, reaction); }
			else
			{
				reactions[eventName] -= reaction;
				reactions[eventName] += reaction;
			}
		}

		public static void Publish(string eventName)
		{
			Publish(eventName, EventData.empty);
		}

		public static void Publish(string eventName, EventData data)
		{
			if (string.IsNullOrEmpty(eventName))
			{ PrintConsole.Warning("Empty event name"); return; }
			if (!reactions.ContainsKey(eventName))
			{ PrintConsole.Warning("No observers to react to '" + eventName + "' event"); return; }

			reactions[eventName](data);
		}

		public static void UnSubscribe(string eventName, SubscriberReaction reaction)
		{
			if (string.IsNullOrEmpty(eventName))
			{ PrintConsole.Error("Empty event name"); return; }
			if (reaction == null)
			{ PrintConsole.Error("Null reaction to '" + eventName + "' event"); return; }

			if (!reactions.ContainsKey(eventName))
			{ PrintConsole.Warning("No '" + eventName + "' event/observers found"); return; }

			reactions[eventName] -= reaction;
			if (Subscriptions(eventName) == 0)
			{ RemoveHub(eventName); }
		}

		/// <summary>
		/// Remove an event and it's list of observers
		/// </summary>
		/// <param name="eventName"></param>
		private static void RemoveHub(string eventName)
		{
			if (string.IsNullOrEmpty(eventName))
			{ PrintConsole.Error("Empty event name"); return; }
			if (!reactions.ContainsKey(eventName))
			{ PrintConsole.Warning("No '" + eventName + "' event/observers found"); return; }

			reactions.Remove(eventName);
		}

		/// <summary>
		/// Return the number of subscriptions
		/// </summary>
		/// <param name="eventName"></param>
		public static int Subscriptions(string eventName)
		{
			if (reactions[eventName] == null)
			{ return 0; }
			return reactions[eventName].GetInvocationList().Length;
		}
	}
}