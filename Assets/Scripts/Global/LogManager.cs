#if UNITY_EDITOR || DEV_BUILD
#define LOG
#endif

using System.Runtime.CompilerServices;
using UnityEngine;

public static class LogManager
{
#if LOG
	private static int logCounter = 0;
#endif
	public static void Log(string argLogMessage, [CallerLineNumber] int _lineNumber = 0, [CallerMemberName] string _callerName = "EMPTY", [CallerFilePath] string _filePath = "EMPTY")
	{
#if UNITY_EDITOR
		Debug.Log($"[{logCounter}, {_callerName}] : {argLogMessage}\nLine {_lineNumber}, Path [{_filePath}]");
#endif

#if LOG
		logCounter++;
#endif
	}
	public static void LogWarning(string argLogMessage, [CallerLineNumber] int _lineNumber = 0, [CallerMemberName] string _callerName = "EMPTY", [CallerFilePath] string _filePath = "EMPTY")
	{
#if UNITY_EDITOR
		Debug.LogWarning($"[{logCounter}, {_callerName}] : {argLogMessage}\nLine {_lineNumber}, Path [{_filePath}]");
#endif

#if LOG
		logCounter++;
#endif
	}
	public static void LogError(string argLogMessage, [CallerLineNumber] int _lineNumber = 0, [CallerMemberName] string _callerName = "EMPTY", [CallerFilePath] string _filePath = "EMPTY")
	{
#if UNITY_EDITOR
		Debug.LogError($"[{logCounter}, {_callerName}] : {argLogMessage}\nLine {_lineNumber}, Path [{_filePath}]");
#endif

#if LOG
		logCounter++;
#endif
	}
}
