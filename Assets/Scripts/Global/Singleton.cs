using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static Object lockPermission = new Object();
	private static volatile T instance = null;
	public static T Instance
	{
		get
		{
			if (isShuttingDown == true)
			{
				return null;
			}
			lock(lockPermission)
			{
				if (instance == null)
				{
					instance = FindObjectOfType(typeof(T)) as T;
				}
				if (instance == null)
				{
					GameObject obj = new GameObject(typeof(T).ToString(), typeof(T));
					obj.GetComponent<T>();
				}
				if (instance == null)
				{
					LogManager.LogError($"Failed to get singleton instance {typeof(T)}");
				}
			}
			return instance;
		}
	}
	private int instanceID = 0;
	protected virtual void Awake()
	{
		instanceID = Random.Range(1000, 9999);
		LogManager.Log($"{typeof(T)}:{instanceID} singleton class awaked.");
		this.gameObject.name = $"{this.gameObject.name}_{instanceID}";
		if (instance == null)
		{
			instance = this as T;
		}
		else
		{
			if (instance != this)
			{
				LogManager.LogWarning($"Same singleton class alive. Destroy new one ({instanceID})");
				DestroyImmediate(this.gameObject);
			}
		}
		DontDestroyOnLoad(this.gameObject);
	}
	public virtual void OnDestroy()
	{
		LogManager.Log($"{typeof(T)}:{instanceID} singleton class destroyed.");
		instance = null;
	}
	protected static bool isShuttingDown = false;
	public virtual void OnApplicationQuit()
	{
		isShuttingDown = true;
		instance = null;
	}
}
