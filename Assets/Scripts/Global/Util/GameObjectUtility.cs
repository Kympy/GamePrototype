using UnityEngine;

public class GameObjectUtility
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
			Object.DontDestroyOnLoad(cachedGameObject);
		}
		return cachedGameObject.GetComponent<T>();
	}
}
