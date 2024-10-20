using UnityEngine;

/// <summary>
/// Wrapper log methods for editor and debug build
/// </summary>
public static class PrintConsole
{
	public static void Log(object message)
	{
		if (!Debug.isDebugBuild)
		{ return; }
		Debug.Log(message);
	}
	public static void Error(object message)
	{
		if (!Debug.isDebugBuild)
		{ return; }
		Debug.LogError(message);
	}
	public static void Warning(object message)
	{
		if (!Debug.isDebugBuild)
		{ return; }
		Debug.LogWarning(message);
	}
}