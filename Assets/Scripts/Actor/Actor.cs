using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : StaticActor
{
	// Current velocity of this actor.
	protected float velocity;
	public float Velocity
	{
		get { return velocity; } 
		set {  velocity = value; }
	}
	// Current jump force of this actor.
	protected float jumpForce;
	public float JumpForce
	{
		get { return jumpForce; }
		set { jumpForce = value; }
	}
}
