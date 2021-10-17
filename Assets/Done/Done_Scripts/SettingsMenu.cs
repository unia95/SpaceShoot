﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu :interface_2 {

	public AudioMixer audioMixer;

	public void SetVolume(float volume){
		
		audioMixer.SetFloat ("volume", volume);
		
	
	}

	public void SetQuality(int qualityIndex){
	QualitySettings.SetQualityLevel (qualityIndex);
	
	}


}
