using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable, IInteract
{
	private bool isOpened = false;
	public void Interact()
	{
		if (isInteractable == false) return;

		isInteractable = false;
		if (isOpened == false)
		{
			IRotate(Quaternion.Euler(0f, 90f, 0f), 4f, InteractCallback);
		}
		else
		{
			IRotate(Quaternion.Euler(0f, -90f, 0f), 4f, InteractCallback);
		}
	}
	public void InteractCallback()
	{
		isInteractable = true;
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Interact();
		}
	}
}
