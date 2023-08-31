using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UIType = EnumCollection.UIType;
using UILayer = EnumCollection.UILayer;
using System;
using UnityEngine.UI;

public class UIManager : ManagerBase
{
	public override void Init()
	{
		base.Init();
		CreateUILayer();
		IsInitialized = true;
	}
	public void CreateUILayer()
	{
		GameObject cache = null;
		string[] layerEnumArray = Enum.GetNames(typeof(UILayer));
		foreach(var layer in layerEnumArray)
		{
			cache = new GameObject($"UI_{layer}");
			var canvas = cache.AddComponent<Canvas>();
			canvas.renderMode = RenderMode.ScreenSpaceOverlay;
			cache.AddComponent<CanvasScaler>();
			cache.AddComponent<GraphicRaycaster>();
			DontDestroyOnLoad(cache);
		}
	}
	public T CreateUI<T>(string resourcePath, UILayer layer, UIType type) where T : UIBase
	{
		var result = Addressables.LoadAssetAsync<T>(resourcePath);
		if (result.Result == null)
		{
			return null;
		}
		Instantiate(result.Result);
		return result.Result;
	}
	private Dictionary<UIType, List<UIBase>> UIContainer = new Dictionary<UIType, List<UIBase>>(); 
	public void CreateTitleUI()
	{
		
	}
}
