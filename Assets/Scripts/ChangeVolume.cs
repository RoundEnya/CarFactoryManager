using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour {

	private AudioSource SoundPlayer;

	// Use this for initialization
	void Start ()
	{
		SoundPlayer = GameObject.Find("Audio Source").GetComponent<AudioSource>();
		gameObject.GetComponent<Slider>().value = SoundPlayer.volume;
	}
	
	public void ChangeMusicVolume()
	{
		SoundPlayer.volume = gameObject.GetComponent<Slider>().value;
	}
}
