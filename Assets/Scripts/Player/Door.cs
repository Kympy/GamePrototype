using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : Interactable, IInteract
{
	private AudioSource m_AudioSource = null;
	protected override void Start()
	{
		base.Awake();
		interactCallback = null;
		interactCallback += () => isInteractable = true;

		var clip = ResourceUtility.LoadAsset<AudioClip>("Assets/Resources_moved/AudioClip/DoorSound.mp3");
		m_AudioSource = this.AddComponent<AudioSource>();
		m_AudioSource.clip = clip.Current;
		m_AudioSource.outputAudioMixerGroup = GameManager.Instance.Audio.GetMasterMixerGroup();
		m_AudioSource.playOnAwake = false;
	}
	private bool isOpened = false;
	private Action interactCallback = null;
	public void Interact()
	{
		if (isInteractable == false) return;

		isInteractable = false;
		m_AudioSource.Play();
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
