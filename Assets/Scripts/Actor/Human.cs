using UnityEngine;
using Gender = EnumCollection.Gender;
public class Human : Actor, IWalkable, ISwimable, IJumpable, IPregnancy
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

	public virtual void Jump()
	{
		if (MyRigidbody == null)
		{
			LogManager.LogError("My rigidbody is null.");
			return;
		}
		if (IsGrounded() == false) return;

		MyRigidbody.AddForce(JumpForce * Vector3.up, ForceMode.Impulse);
	}
	private Transform footPivot = null;
	// Is actor's foot on the ground?
	public virtual bool IsGrounded()
	{
		if (footPivot == null)
		{
			LogManager.LogError("Foot pivot is null.");
			return false;
		}
		return Physics.CheckBox(footPivot.position, Vector3.one);
	}
	protected Gender gender = Gender.Unknown;
	public Gender MyGender
	{
		get { return gender; }
		set { gender = value; }
	}
	public virtual void Pregnance()
	{
		if (gender != Gender.Female) return;
	}

	public virtual void ChildBirth()
	{
		if (gender != Gender.Female) return;
	}
}
