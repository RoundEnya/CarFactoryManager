using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaterieManager : MonoBehaviour {

	public Sprite[] baterii = new Sprite[6];
	public Image baterieCurenta;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		switch(ProfileManager.maxUpgradeProfit)
		{
			case 1:
				baterieCurenta.sprite = baterii[0];
				break;
			case 2:
				baterieCurenta.sprite = baterii[1];
				break;
			case 3:
				baterieCurenta.sprite = baterii[2];
				break;
			case 4:
				baterieCurenta.sprite = baterii[3];
				break;
			case 5:
				baterieCurenta.sprite = baterii[4];
				break;
			case 6:
				baterieCurenta.sprite = baterii[5];
				break;
		}
	}
}
