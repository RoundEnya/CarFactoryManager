using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpgradeManager : MonoBehaviour {

    public Text text_UpQuality;
    public Text text_UpProfit;

    public Button button_quality;
    public Button button_profit;
    public Button unlockUpgradeButton;

    private int[] upgradeQualityPrices = new int[5];
    private int[] upgradeProfitPrices = new int[5];

    int[] carPrices = new int[6];


    private void Start()
    {
        SetQualityUpgradePrices();
        SetProfitUpgradePrices();

        text_UpQuality.text = upgradeQualityPrices[ProfileManager.maxUpgradeQuality - 1].ToString();
        text_UpProfit.text = upgradeProfitPrices[ProfileManager.maxUpgradeProfit - 1].ToString();

        if (ProfileManager.maxUpgradeQuality >= 6)
        {
            button_quality.enabled = false;
        }

        carPrices[0] = 3320;
        carPrices[1] = 11200;
        carPrices[2] = 32200;
        carPrices[3] = 105000;
        carPrices[4] = 311000;
        carPrices[5] = 820000;
    }

    public void UnlockUpgrade ()
    {
        if (!ProfileManager.unlockUpgrade)
        {
            SceneManager.LoadScene("Quiz_Main");
        }
        else
        {
            unlockUpgradeButton.enabled = false;
        }
    }


	public void UpgradeQuality()
	{
		if(ProfileManager.maxUpgradeQuality <= 5 && ProfileManager.bani >= Convert.ToUInt64(text_UpQuality.text) && ProfileManager.unlockUpgrade)
		{
			ProfileManager.bani -= Convert.ToUInt64(text_UpQuality.text);
			
			ProfileManager.maxUpgradeQuality++;
			text_UpQuality.text = upgradeQualityPrices[ProfileManager.maxUpgradeQuality - 1].ToString();

            ProfileManager.motoare=0;
            ProfileManager.cutii=0;
            ProfileManager.roti=0;
            ProfileManager.caroserii=0;
            ProfileManager.altele=0;
            ProfileManager.masina = false;

            unlockUpgradeButton.enabled = true;
            ProfileManager.unlockUpgrade = false;
		}
		if (ProfileManager.maxUpgradeQuality > 5)
		{
			button_quality.enabled = false;
		}
		ProfileManager PM = new ProfileManager();
		PM.SetData();
	}

	public void UpgradeProfit()
	{
		if (ProfileManager.maxUpgradeProfit <= 5 && ProfileManager.bani >= Convert.ToUInt64(text_UpProfit.text))
		{
			ProfileManager.bani -= Convert.ToUInt64(text_UpProfit.text);

			ProfileManager.maxUpgradeProfit++;
			ProfileManager.procentProfit += 0.2f;
			text_UpProfit.text = upgradeProfitPrices[ProfileManager.maxUpgradeProfit - 1].ToString();

			ProfileManager PM = new ProfileManager();
			PM.SetData();
		}
		if (ProfileManager.maxUpgradeProfit > 5)
		{
			button_quality.enabled = false;
		}
	}

	private void SetQualityUpgradePrices()
	{
		upgradeQualityPrices[0] = 150000;
		upgradeQualityPrices[1] = 600000;
		upgradeQualityPrices[2] = 1500000;
		upgradeQualityPrices[3] = 4000000;
		upgradeQualityPrices[4] = 20000000;
	}

	private void SetProfitUpgradePrices()
	{
		upgradeProfitPrices[0] = 500000;
		upgradeProfitPrices[1] = 900000;
		upgradeProfitPrices[2] = 4000000;
		upgradeProfitPrices[3] = 7000000;
		upgradeProfitPrices[4] = 20000000;
	}
}
