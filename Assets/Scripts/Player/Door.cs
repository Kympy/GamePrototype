using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable, IInteract
{
	protected override void Awake()
	{
		base.Awake();
		interactCallback = null;
		interactCallback += () => isInteractable = true;
	}
	private bool isOpened = false;
	private Action interactCallback = null;
	public void Interact()
	{
		if (isInteractable == false) return;

		isInteractable = false;
		if (isOpened == false)
		{
			IRotate(Quaternion.Euler(0f, 90f, 0f), 4f, interactCallback);
		}
		else
		{
			IRotate(Quaternion.Euler(0f, -90f, 0f), 4f, interactCallback);
		}
	}
	public void AddCallback(Action argCallbackAction)
	{
		interactCallback += argCallbackAction;
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Interact();
		}
	}
}
