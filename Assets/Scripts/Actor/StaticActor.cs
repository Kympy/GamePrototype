using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticActor : MonoBehaviour, IInit
{
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

	public virtual void Init()
	{

	}
}
