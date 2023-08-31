using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Interactable : StaticActor
{
	private Task interactTask = null;
	private CancellationTokenSource interactionTokenSource = new CancellationTokenSource();
	public virtual void IRotate(Quaternion rotateAmount, float speed, Action completeAction = null)
	{
		// Do Rotate Here
		interactTask = new Task(async () =>
		{
			Quaternion targetRotation = transform.rotation * rotateAmount;
			float timer = 0f;
			while(true)
			{
				if (interactionTokenSource.IsCancellationRequested == true)
				{
					LogManager.Log("Canceled rotation.");
					break;
				}
				if (Quaternion.Angle(transform.rotation, targetRotation) <= 0.1f)
				{
					LogManager.Log($"Finished rotation. Time : {timer}");
					break;
				}
				transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * speed);
				timer += Time.deltaTime;
				await Task.Yield();
			}
			completeAction?.Invoke();
		},interactionTokenSource.Token);
		interactTask.RunSynchronously();
	}
	public virtual void IRotate(float rotateTime, Action completeAction = null)
	{
		// Do Rotate Here
		completeAction?.Invoke();
	}
	public virtual void IMove()
	{

	}
	public virtual void IPlaySound()
	{

	}
	public virtual void IScaleUp()
	{

	}
	public override void OnDestroy()
	{
		base.OnDestroy();
		interactionTokenSource?.Cancel();
	}
}