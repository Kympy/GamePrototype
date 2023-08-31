using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticActor : MonoBehaviour, IInit
{
	protected virtual void Awake() { }
	protected virtual void Start() { }
	public virtual void OnEnable() { }
	public virtual void OnDisable() { }
	public virtual void OnDestroy() { }
	// The custom name of gameObject
	private string name_Internal;
	public string Name
	{
		get
		{
			return name_Internal;
		}
		protected set
		{
			name_Internal = value;
		}
	}
	// Base initialization. Because of the controling sequence.
	public virtual void Init()
	{
		
	}
	private Collider rootCollider = null;
	// Get root collider of this actor.
	public Collider RootCollider
	{
		get
		{
            if (rootCollider == null)
            {
				TryGetComponent(out rootCollider);
            }
			return rootCollider;
        }
	}
	// Get all colliders attached to this actor.
	public Collider[] GetAllColliders(bool includeInactivate = false)
	{
		return GetComponentsInChildren<Collider>(includeInactivate);
	}
	private new Rigidbody rigidbody = null;
	// Get rigidbody of this actor.
	public Rigidbody MyRigidbody
	{
		get
		{
			if (rigidbody == null)
			{
				TryGetComponent(out rigidbody);
			}
			return rigidbody;
		}
	}
	// Is this actor activated?
	public bool IsActive
	{
		get { return this.gameObject.activeSelf; }
	}
	protected bool isInteractable = true;
	public void SetInteractable(bool argInteractable)
	{
		isInteractable = argInteractable;
	}
}
