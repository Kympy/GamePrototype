using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gender = EnumCollection.Gender;
public class Animal : Actor, IWalkable, ISwimable, IPregnancy
{
	protected Gender gender = Gender.Unknown;
	public Gender MyGender
	{
		get { return gender; }
		set { gender = value; }
	}
	public virtual void ChildBirth()
	{
		if (gender != Gender.Female) return;
	}

	public virtual void Pregnance()
	{
		if (gender != Gender.Female) return;
	}

	public virtual void Swim()
	{

	}

	public virtual void Walk()
	{

	}
}
