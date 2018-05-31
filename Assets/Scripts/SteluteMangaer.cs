using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SteluteMangaer : MonoBehaviour {

	public Image[] steluteImagini = new Image[6];
	public Sprite steluta_valoare;
	public Sprite steluta_saracie;

	private void Start()
	{
		
	}

	private void Update()
	{
		switch(ProfileManager.maxUpgradeQuality)
		{
			case 1:
				steluteImagini[0].sprite = steluta_valoare;
				steluteImagini[1].sprite = steluta_saracie;
				steluteImagini[2].sprite = steluta_saracie;
				steluteImagini[3].sprite = steluta_saracie;
				steluteImagini[4].sprite = steluta_saracie;
				steluteImagini[5].sprite = steluta_saracie;
				break;
			case 2:
				steluteImagini[0].sprite = steluta_valoare;
				steluteImagini[1].sprite = steluta_valoare;
				steluteImagini[2].sprite = steluta_saracie;
				steluteImagini[3].sprite = steluta_saracie;
				steluteImagini[4].sprite = steluta_saracie;
				steluteImagini[5].sprite = steluta_saracie;
				break;
			case 3:
				steluteImagini[0].sprite = steluta_valoare;
				steluteImagini[1].sprite = steluta_valoare;
				steluteImagini[2].sprite = steluta_valoare;
				steluteImagini[3].sprite = steluta_saracie;
				steluteImagini[4].sprite = steluta_saracie;
				steluteImagini[5].sprite = steluta_saracie;
				break;
			case 4:
				steluteImagini[0].sprite = steluta_valoare;
				steluteImagini[1].sprite = steluta_valoare;
				steluteImagini[2].sprite = steluta_valoare;
				steluteImagini[3].sprite = steluta_valoare;
				steluteImagini[4].sprite = steluta_saracie;
				steluteImagini[5].sprite = steluta_saracie;
				break;
			case 5:
				steluteImagini[0].sprite = steluta_valoare;
				steluteImagini[1].sprite = steluta_valoare;
				steluteImagini[2].sprite = steluta_valoare;
				steluteImagini[3].sprite = steluta_valoare;
				steluteImagini[4].sprite = steluta_valoare;
				steluteImagini[5].sprite = steluta_saracie;
				break;
			case 6:
				steluteImagini[0].sprite = steluta_valoare;
				steluteImagini[1].sprite = steluta_valoare;
				steluteImagini[2].sprite = steluta_valoare;
				steluteImagini[3].sprite = steluta_valoare;
				steluteImagini[4].sprite = steluta_valoare;
				steluteImagini[5].sprite = steluta_valoare;
				break;
		}
	}
}
