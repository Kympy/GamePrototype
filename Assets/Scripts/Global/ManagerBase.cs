using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ManagerBase : MonoBehaviour, IInit
{
	protected int instanceID = 0;
	protected virtual void Awake()
	{
		LogManager.Log($"{this.GetType()} is created.");
		instanceID = Random.Range(1, 9999);
		this.gameObject.name = $"{this.gameObject.name}_{instanceID}";
	}
	public bool IsInitialized { get; protected set; } = false;
	public virtual void Init() { }
	public virtual void OnDestroy()
	{
		LogManager.Log($"{this.GetType()} is destroyed.");
	}
}
