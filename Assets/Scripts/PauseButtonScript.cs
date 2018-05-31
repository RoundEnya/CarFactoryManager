using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonScript : MonoBehaviour {

    private SoundPlayer SP;
    private Button button_pause;

    // Use this for initialization
    void Start()
    {
        SP = GameObject.Find("Audio Source").GetComponent<SoundPlayer>();
        button_pause = this.gameObject.GetComponent<Button>();
        button_pause.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        SP.MpPlayer.Pause();
        SP.paused = true;
    }
}
