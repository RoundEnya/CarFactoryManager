using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

    public AudioSource MpPlayer;
    public AudioClip[] melodii = new AudioClip[12];

    public int melodie_curenta;
    public bool paused;

    private static SoundPlayer instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }

        Destroy(this.gameObject);
    }

    // Use this for initialization
    void Start ()
    {
        melodie_curenta = 0;
        MpPlayer.clip = melodii[melodie_curenta];
        StartCoroutine(WaitForTrackToEnd());
	}
	

    IEnumerator WaitForTrackToEnd()
    {
        while (MpPlayer.isPlaying)
        {

            yield return new WaitForSeconds(0.01f);

        }
        melodie_curenta++;
        if(melodie_curenta>=12)
        {
            melodie_curenta = 0;
        }
        MpPlayer.clip = melodii[melodie_curenta];
        MpPlayer.Play();
    }

    //public void PlayMusic()
    //{
    //    if(paused)
    //    {
    //        MpPlayer.UnPause();
    //        paused = false;
    //    }
    //    else
    //    {
    //        MpPlayer.Play();
    //    }
    //}

    //public void PauseMusic()
    //{
    //    MpPlayer.Pause();
    //    paused = true;
    //}

    public void NextTrack()
    {
        SoundPlayer sp = GameObject.Find("Audio Source").GetComponent<SoundPlayer>();
        melodie_curenta++;
        if(melodie_curenta>=12)
        {
            melodie_curenta = 0;
        }
        MpPlayer.clip = melodii[melodie_curenta];
        if(!paused)
        {
            MpPlayer.Play();
        }
    }
}
