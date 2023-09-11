using UnityEngine;

public class GameManager : Singleton<GameManager>, IInit
{
	protected override void Awake()
	{
		base.Awake();
		Init();
	}
	public AudioManager Audio { get; private set; } = null;
	public void Init()
	{
		Audio = GameObjectUtility.MakeAndGetComponent<AudioManager>();
		Audio.Init();
	}
}