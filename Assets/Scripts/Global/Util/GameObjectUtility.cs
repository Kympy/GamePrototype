using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectUtility : MonoBehaviour
{
	private static GameObject cachedGameObject = null;
	public static T MakeAndGetComponent<T>(Transform parentTransform = null, bool dontDestroy = false) where T : MonoBehaviour
	{
		cachedGameObject = new GameObject(typeof(T).ToString(), typeof(T));
		if (parentTransform != null)
		{
			cachedGameObject.transform.SetParent(parentTransform);
		}
		if (dontDestroy == true)
		{
			DontDestroyOnLoad(cachedGameObject);
		}
		return cachedGameObject.GetComponent<T>();
	}
}
