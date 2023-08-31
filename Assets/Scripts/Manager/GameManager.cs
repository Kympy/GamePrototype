using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameObjectUtility;
public class GameManager : Singleton<GameManager>, IInit
{
	protected override void Awake()
	{
		base.Awake();
		Init();
	}
	public bool IsInitialized { get; private set; } = false;
	#region [ Manager ]
	private UIManager UI = null;
	private AudioManager Audio = null;
	#endregion
	public void Init()
	{
        if (IsInitialized == true)
        {
			LogManager.LogError("GameManager Init() is already called.");
			return;
        }
		try
		{
			UI = MakeAndGetComponent<UIManager>(parentTransform: this.transform);
			Audio = MakeAndGetComponent<AudioManager>(parentTransform: this.transform);

			UI.Init();
		}
		catch(System.Exception ex)
		{
			LogManager.LogError($"{ex}");
			IsInitialized = false;
		}
		IsInitialized = true;
	}
}