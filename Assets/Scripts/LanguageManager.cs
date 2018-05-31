using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class LanguageManager : MonoBehaviour {

	public static string language = "English";

	public Text[] mainInterfaceText;
	public Text[] settingsText;
	public Text[] profileSceneText;
	public Text[] createProfileText;
	public Text[] mainSceneText;
	public Text[] buyPartsText;
	public Text[] upgradeText;
	public Text[] profileText;
	public Text[] infoSceneText;
    public Text[] quizText;

	private TextAsset languageFile;


    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Quiz")
        {
            string[] fLines;
            languageFile = Resources.Load(@language + "/Quiz") as TextAsset;
            quizText = new Text[8];

            quizText[0] = GameObject.Find("Congrats_text").GetComponent<Text>();
            quizText[1] = GameObject.Find("UpgradeAvailableText").GetComponent<Text>();
            quizText[2] = GameObject.Find("goToShopText").GetComponent<Text>();
            quizText[3] = GameObject.Find("redoInfText").GetComponent<Text>();
            quizText[4] = GameObject.Find("redoText").GetComponent<Text>();
            quizText[5] = GameObject.Find("shopText").GetComponent<Text>();
            quizText[6] = GameObject.Find("anotherText").GetComponent<Text>();
            quizText[7] = GameObject.Find("goToCatText").GetComponent<Text>();

            fLines = languageFile.text.Split("\n"[0]);
            quizText[0].text = fLines[0];
            quizText[1].text = fLines[1];
            quizText[2].text = fLines[2];
            quizText[3].text = fLines[3];
            quizText[4].text = fLines[4];
            quizText[5].text = fLines[5];
            quizText[6].text = fLines[6];
            quizText[7].text = fLines[7];
        }

    }

    void Start () {

		string[] fLines;
		switch(SceneManager.GetActiveScene().name)
		{
            case "main_interface":
				languageFile = Resources.Load(@language + "/main_interface") as TextAsset;
				mainInterfaceText = new Text[3];
				mainInterfaceText[0] = GameObject.Find("startButtonText").GetComponent<Text>();
				mainInterfaceText[1] = GameObject.Find("settingsButtonText").GetComponent<Text>();
				mainInterfaceText[2] = GameObject.Find("quitButtonText").GetComponent<Text>();
				fLines = languageFile.text.Split("\n"[0]);

				mainInterfaceText[0].text = fLines[0];
				mainInterfaceText[1].text = fLines[1];
				mainInterfaceText[2].text = fLines[2];

				break;
			case "settings":
				languageFile = Resources.Load(@language + "/settings") as TextAsset;
				settingsText = new Text[2];
				settingsText[0] = GameObject.Find("MusicText").GetComponent<Text>();
				settingsText[1] = GameObject.Find("LanguageText").GetComponent<Text>();

				fLines = languageFile.text.Split("\n"[0]);
				settingsText[0].text = fLines[0];
				settingsText[1].text = fLines[1];

				break;
			case "profile_scene":
				languageFile = Resources.Load(@language + "/profile_scene") as TextAsset;
				profileSceneText = new Text[3];

				// TODO enter object names
				profileSceneText[0] = GameObject.Find("profile1_text").GetComponent<Text>();
				profileSceneText[1] = GameObject.Find("profile2_text").GetComponent<Text>();
				profileSceneText[2] = GameObject.Find("profile3_text").GetComponent<Text>();

				fLines = languageFile.text.Split("\n"[0]);
				profileSceneText[0].text = fLines[0];
				profileSceneText[1].text = fLines[1];
				profileSceneText[2].text = fLines[2];

				break;
			case "create_profile":
				languageFile = Resources.Load(@language + "/create_profile") as TextAsset;
				createProfileText = new Text[3];

				// TODO enter object names
				createProfileText[0] = GameObject.Find("Name").GetComponent<Text>();
				createProfileText[1] = GameObject.Find("ageShow").GetComponent<Text>();
				createProfileText[2] = GameObject.Find("createButton_text").GetComponent<Text>();

				fLines = languageFile.text.Split("\n"[0]);
				createProfileText[0].text = fLines[0];
				createProfileText[1].text = fLines[1];
				createProfileText[2].text = fLines[2];

				break;
			case "main_scene":
				languageFile = Resources.Load(@language + "/main_scene") as TextAsset;
				mainSceneText = new Text[11];

				// TODO enter object names
				mainSceneText[0] = GameObject.Find("musicText").GetComponent<Text>();
				mainSceneText[1] = GameObject.Find("money_text").GetComponent<Text>();
				mainSceneText[2] = GameObject.Find("Motoare_text").GetComponent<Text>();
				mainSceneText[3] = GameObject.Find("Cutii_text").GetComponent<Text>();
				mainSceneText[4] = GameObject.Find("Caroserii_text").GetComponent<Text>();
				mainSceneText[5] = GameObject.Find("Roti_text").GetComponent<Text>();
				mainSceneText[6] = GameObject.Find("Altele_text").GetComponent<Text>();
				mainSceneText[7] = GameObject.Find("buyButton_text").GetComponent<Text>();
				mainSceneText[8] = GameObject.Find("upgradeButton_text").GetComponent<Text>();

				fLines = languageFile.text.Split("\n"[0]);
				mainSceneText[0].text = fLines[0];
				mainSceneText[1].text = fLines[1];
				mainSceneText[2].text = fLines[2];
				mainSceneText[3].text = fLines[3];
				mainSceneText[4].text = fLines[4];
				mainSceneText[5].text = fLines[5];
				mainSceneText[6].text = fLines[6];
				mainSceneText[7].text = fLines[7];
				mainSceneText[8].text = fLines[8];
				break;
			case "buy_parts":
				languageFile = Resources.Load(@language + "/buy_parts") as TextAsset;
				buyPartsText = new Text[14];

				// TODO enter object names
				buyPartsText[0] = GameObject.Find("Bani_text").GetComponent<Text>();
				buyPartsText[1] = GameObject.Find("Shop").GetComponent<Text>();
				buyPartsText[2]	= GameObject.Find("Car Parts").GetComponent<Text>();
				buyPartsText[3]	= GameObject.Find("Quality").GetComponent<Text>();
				buyPartsText[4]	= GameObject.Find("Quantity").GetComponent<Text>();
				buyPartsText[5]	= GameObject.Find("Price").GetComponent<Text>();
				buyPartsText[6]	= GameObject.Find("Buy").GetComponent<Text>();
				buyPartsText[7]	= GameObject.Find("MotorText").GetComponent<Text>();
				buyPartsText[8]	= GameObject.Find("cutie_text").GetComponent<Text>();
				buyPartsText[9] = GameObject.Find("roata_text").GetComponent<Text>();
				buyPartsText[10] = GameObject.Find("caroserie_text").GetComponent<Text>();
				buyPartsText[11] = GameObject.Find("altele_text").GetComponent<Text>();

                fLines = languageFile.text.Split("\n"[0]);
				buyPartsText[0].text = fLines[0];
				buyPartsText[1].text = fLines[1];
				buyPartsText[2].text = fLines[2];
				buyPartsText[3].text = fLines[3];
				buyPartsText[4].text = fLines[4];
				buyPartsText[5].text = fLines[5];
				buyPartsText[6].text = fLines[6];
				buyPartsText[7].text = fLines[7];
				buyPartsText[8].text = fLines[8];
				buyPartsText[9].text = fLines[9];
				buyPartsText[10].text = fLines[10];
				buyPartsText[11].text = fLines[11];
                break;
			case "Upgrade":
				languageFile = Resources.Load(@language + "/Upgrade") as TextAsset;
				upgradeText = new Text[7];

				upgradeText[0] = GameObject.Find("bani_text").GetComponent<Text>();
				upgradeText[1] = GameObject.Find("upgrades_text").GetComponent<Text>();
				upgradeText[2] = GameObject.Find("Quality_Text").GetComponent<Text>();
				upgradeText[3] = GameObject.Find("Profit_Text").GetComponent<Text>();
				upgradeText[4] = GameObject.Find("quality_price").GetComponent<Text>();
				upgradeText[5] = GameObject.Find("Price_Tag").GetComponent<Text>();
                upgradeText[6] = GameObject.Find("unlockUpgradeText").GetComponent<Text>();
                
                fLines = languageFile.text.Split("\n"[0]);
				upgradeText[0].text = fLines[0];
				upgradeText[1].text = fLines[1];
				upgradeText[2].text = fLines[2];
				upgradeText[3].text = fLines[3];
				upgradeText[4].text = fLines[4];
				upgradeText[5].text = fLines[5];
                upgradeText[6].text = fLines[6];
				break;
			case "Profile_1":
				languageFile = Resources.Load(@language + "/Profile_1") as TextAsset;
				profileText = new Text[10];

				profileText[0] = GameObject.Find("profileInfo_Text").GetComponent<Text>();
				profileText[1] = GameObject.Find("Stats").GetComponent<Text>(); 
				profileText[2] = GameObject.Find("Max_Quality").GetComponent<Text>(); 
				profileText[3] = GameObject.Find("Money").GetComponent<Text>();
				profileText[4] = GameObject.Find("Cars_sold").GetComponent<Text>();
				profileText[5] = GameObject.Find("Total_earnings").GetComponent<Text>();
				profileText[6] = GameObject.Find("Time_spent").GetComponent<Text>();
				profileText[7] = GameObject.Find("Name").GetComponent<Text>(); 
				profileText[8] = GameObject.Find("Age").GetComponent<Text>();

				fLines = languageFile.text.Split("\n"[0]);
				profileText[0].text = fLines[0];
				profileText[1].text = fLines[1];
				profileText[2].text = fLines[2];
				profileText[3].text = fLines[3];
				profileText[4].text = fLines[4];
				profileText[5].text = fLines[5];
				profileText[6].text = fLines[6];
				profileText[7].text = fLines[7];
				profileText[8].text = fLines[8];
				break;			 
			case "info_scene":	 
				languageFile = Resources.Load(@language + "/info_scene") as TextAsset;
				infoSceneText = new Text[8];

				infoSceneText[0] = GameObject.Find("gameInfo_text").GetComponent<Text>();
				infoSceneText[1] = GameObject.Find("howToPlayText").GetComponent<Text>();
				infoSceneText[2] = GameObject.Find("buyParts_text").GetComponent<Text>();
				infoSceneText[3] = GameObject.Find("Detalii (1)").GetComponent<Text>();
				infoSceneText[4] = GameObject.Find("assemble_text").GetComponent<Text>();
				infoSceneText[5] = GameObject.Find("Detalii (2)").GetComponent<Text>();
				infoSceneText[6] = GameObject.Find("upgrade_text").GetComponent<Text>();
				infoSceneText[7] = GameObject.Find("Detalii (3)").GetComponent<Text>();

				fLines = languageFile.text.Split("\n"[0]);
				infoSceneText[0].text = fLines[0];
				infoSceneText[1].text = fLines[1];
				infoSceneText[2].text = fLines[2];
				infoSceneText[3].text = fLines[3];
				infoSceneText[4].text = fLines[4];
				infoSceneText[5].text = fLines[5];
                infoSceneText[6].text = fLines[6];
                infoSceneText[7].text = fLines[7];
				break;
        }
	}

	public void SetLanguage(string lang)
	{
		language = lang;

		languageFile = Resources.Load(@language + "/settings") as TextAsset;
		settingsText = new Text[2];
		settingsText[0] = GameObject.Find("MusicText").GetComponent<Text>();
		settingsText[1] = GameObject.Find("LanguageText").GetComponent<Text>();

		string[] fLines = languageFile.text.Split("\n"[0]);
		settingsText[0].text = fLines[0];
		settingsText[1].text = fLines[1];
	}
}
