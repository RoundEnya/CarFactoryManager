using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextTrackButtonScript : MonoBehaviour {

    private SoundPlayer SP;
    private Button button_next;

    // Use this for initialization
    void Start()
    {
        SP = GameObject.Find("Audio Source").GetComponent<SoundPlayer>();
        button_next = this.gameObject.GetComponent<Button>();
        button_next.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        SP.melodie_curenta++;
        if (SP.melodie_curenta >= 12)
        {
            SP.melodie_curenta = 0;
        }
        SP.MpPlayer.clip = SP.melodii[SP.melodie_curenta];
        if (!SP.paused)
        {
            SP.MpPlayer.Play();
        }
    }


}
