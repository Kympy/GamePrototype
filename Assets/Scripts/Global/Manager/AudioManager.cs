using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : ManagerBase
{
	private AudioMixer GlobalMixer = null;
	public override void Init()
	{
		base.Init();
		GlobalMixer = ResourceUtility.LoadAsset<AudioMixer>("Assets/Resources_moved/GlobalMixer.mixer").Current;
	}
	public AudioMixerGroup GetMasterMixerGroup()
	{
		return GlobalMixer.outputAudioMixerGroup;
	}
}