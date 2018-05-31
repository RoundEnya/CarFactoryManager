using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButtonScript : MonoBehaviour {

    private SoundPlayer SP;
    private Button button_play;

	// Use this for initialization
	void Start ()
    {
        SP = GameObject.Find("Audio Source").GetComponent<SoundPlayer>();
        button_play = this.gameObject.GetComponent<Button>();
        button_play.onClick.AddListener(OnButtonClick);
	}
	
	void OnButtonClick()
    {
        if (SP.paused)
        {
            SP.MpPlayer.UnPause();
            SP.paused = false;
        }
        else
        {
            SP.MpPlayer.Play();
        }
    }
}
