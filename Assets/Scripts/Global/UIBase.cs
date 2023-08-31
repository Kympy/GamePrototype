using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIBase : MonoBehaviour, IInit
{
	protected virtual void Awake()
	{
		LogManager.Log($"{GetType()} is created.");
	}
	public virtual void Init() { }
	public virtual void OnDestroy()
	{
		LogManager.Log($"{GetType()} is destroyed.");
	}
	public void Show()
	{
		BeforeShow();
		this.gameObject.SetActive(true);
		transform.SetAsLastSibling();
		AfterShow();
	}
	protected virtual void BeforeShow() { }
	protected virtual void AfterShow() { }
	public void Hide()
	{
		BeforeHide();
		this.gameObject.SetActive(false);
		AfterHide();
	}
	protected virtual void BeforeHide() { }
	protected virtual void AfterHide() { }
	public void BringFront()
	{
		transform.SetAsLastSibling();
	}
}
