using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Actor, IWalkable, ISwimable
{
	public override void Init()
	{
		base.Init();
	}
	public virtual void Walk()
	{
		
	}
	public virtual void Swim()
	{
		
	}
}
