using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftCadou : MonoBehaviour {

	public Button button_cadou;

	public static float timer = 0;
	public bool bButtonEnabled = false;

	int[] carPrices = new int[6];

	private void Start()
	{
		carPrices[0] = 3320;
		carPrices[1] = 112000;
		carPrices[2] = 322000;
		carPrices[3] = 1050000;
		carPrices[4] = 3110000;
		carPrices[5] = 8200000;

		button_cadou.interactable = false;
	}
	private void Update()
	{
		if(!bButtonEnabled)
		{
			timer += 1 * Time.deltaTime;
			ShowBox();
		}
	}

	void ShowBox()
	{
		if (timer >= 120)
		{
			bButtonEnabled = true;
			timer = 0;
			button_cadou.interactable = true;
		}
	}

	public void DisableBox()
	{
		ProfileManager.bani += Convert.ToUInt64(carPrices[ProfileManager.maxUpgradeQuality -1 ] / 4);
        ProfileManager.totalEarnings += Convert.ToInt64(carPrices[ProfileManager.maxUpgradeQuality - 1] / 4);
		button_cadou.interactable = false;
		bButtonEnabled = false;

        // Salvez astea
        ProfileManager PM = new ProfileManager();
        PM.SetData();
	}
}
