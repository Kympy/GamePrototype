using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ResourceUtility
{
	public static IEnumerator<T> LoadAsset<T>(string path)
	{
		var result = Addressables.LoadAssetAsync<T>(path);
		yield return result.Result;
	}
	public static GameObject LoadAsset(string path)
	{
		return Addressables.LoadAssetAsync<GameObject>(path).Result;
	}
}
