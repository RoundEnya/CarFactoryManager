using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyManager : MonoBehaviour
{
	public InputField inputField;
	public Text priceText;
	public int tip;

	private float[] pret_motor		= new float[6];
	private float[] pret_cutie		= new float[6];
	private float[] pret_roti		= new float[6];
	private float[] pret_caroserie	= new float[6];
	private float[] pret_altele		= new float[6];

	private void Start()
	{
		pret_motor[0] = 650;
		pret_motor[1] = 20000;
		pret_motor[2] = 60000;
		pret_motor[3] = 200000;
		pret_motor[4] = 600000;
		pret_motor[5] = 1600000;

		pret_cutie[0] = 250;
		pret_cutie[1] = 10000;
		pret_cutie[2] = 30000;
		pret_cutie[3] = 100000;
		pret_cutie[4] = 300000;
		pret_cutie[5] = 800000;

		pret_caroserie[0] = 500;
		pret_caroserie[1] = 25000;
		pret_caroserie[2] = 75000;
		pret_caroserie[3] = 250000;
		pret_caroserie[4] = 750000;
		pret_caroserie[5] = 2000000;

		pret_roti[0] = 700;
		pret_roti[1] = 27000;
		pret_roti[2] = 81000;
		pret_roti[3] = 270000;
		pret_roti[4] = 810000;
		pret_roti[5] = 2160000;

		pret_altele[0] = 420;
		pret_altele[1] = 18000;
		pret_altele[2] = 54000;
		pret_altele[3] = 180000;
		pret_altele[4] = 540000;
		pret_altele[5] = 1440000;

		SetPrice();
	}

	public void Increase()
	{
		if(inputField.text.Length!=0)
		{
			if (Convert.ToInt32(inputField.text)>=5)
			{
				inputField.text = 5.ToString();
			}
			else
			{
				inputField.text = (Convert.ToInt32(inputField.text) + 1).ToString();
			}

		}
		else
		{
			inputField.text = "1";
		}
		SetPrice();

	}

	public void Decrease()
	{
		if (inputField.text.Length != 0)
		{
			if (Convert.ToInt32(inputField.text) <= 1)
			{
				inputField.text = 1.ToString();
			}
			else
			{
				inputField.text = (Convert.ToInt32(inputField.text) - 1).ToString();
			}
		}
		else
		{
			inputField.text = "1";
		}
		SetPrice();
	}

	void SetPrice()
	{
		switch(tip)
		{
			case 1: priceText.text = (Convert.ToInt64(inputField.text) * pret_motor[ProfileManager.maxUpgradeQuality-1]).ToString();
				break;
			case 2:
				priceText.text = (Convert.ToInt64(inputField.text) * pret_cutie[ProfileManager.maxUpgradeQuality - 1]).ToString();
				break;
			case 3:
				priceText.text = (Convert.ToInt64(inputField.text) * pret_roti[ProfileManager.maxUpgradeQuality - 1]).ToString();
				break;
			case 4:
				priceText.text = (Convert.ToInt64(inputField.text) * pret_caroserie[ProfileManager.maxUpgradeQuality - 1]).ToString();
				break;
			case 5:
				priceText.text = (Convert.ToInt64(inputField.text) * pret_altele[ProfileManager.maxUpgradeQuality - 1]).ToString();
				break;
			case 6:
				break;
		}
	}

	public void Buy()
	{
		if(ProfileManager.bani < Convert.ToUInt64(priceText.text))
		{
			return;
		}

		ProfileManager.bani -= Convert.ToUInt64(priceText.text);
		switch (tip)
		{
			case 1: ProfileManager.motoare += Convert.ToInt32(inputField.text);
				break;
			case 2: ProfileManager.cutii += Convert.ToInt32(inputField.text);
				break;
			case 3: ProfileManager.roti += Convert.ToInt32(inputField.text);
				break;
			case 4: ProfileManager.caroserii += Convert.ToInt32(inputField.text);
				break;
			case 5: ProfileManager.altele += Convert.ToInt32(inputField.text);
				break;
			case 6:
				break;
		}

		ProfileManager PM = new ProfileManager();
		PM.SetData();
	}
}
