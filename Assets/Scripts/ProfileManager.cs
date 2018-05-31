using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProfileManager : MonoBehaviour
{
	public Text nameText;
	public Slider slider;

	public GameObject carPrefab;

	string address1 = @"C:\\Users\\" + Environment.UserName + "\\Documents\\profile_1.vrumm";
	string address2 = @"C:\\Users\\" + Environment.UserName + "\\Documents\\profile_2.vrumm";
	string address3 = @"C:\\Users\\" + Environment.UserName + "\\Documents\\profile_3.vrumm";

	public static int age;
	public static string playerName;
	public static int profile_index;
	public static int picture_index=1;
	public static int maxUpgradeQuality = 1;
	public static int maxUpgradeProfit = 1;
	public static float procentProfit = 0;

	public static UInt64 bani = 5000;

	public static int motoare;
	public static int cutii;
	public static int caroserii;
	public static int roti;
	public static int altele;

	public static bool masina;

	public static bool profile_1_created;
	public static bool profile_2_created;
	public static bool profile_3_created;

	public static int masini_vandute;
	public static Int64 totalEarnings;
	public static float seconds;
	public static float minutes;
	public static float hours;
	public static float days;
	public static int activeBackground = 1;

	public Sprite[] poze_profil = new Sprite[10];
	public Sprite poza_goala;
	public Image[] poze_puse = new Image[3];
	public Text[] nume_profiluri = new Text[3];

	public Text[] numar_piese = new Text[5];

	public Image profil_pic_ingame_MainScene;
	public Text player_name_MainScene;

	public Text BaniCounter;

	public Text ageText;
	public Text soldCarsCounter;
	public Text totalEarningsText;
	public Text totalTimeCounter;

    public static int[] quizNumber = new int[12];
    public static int[] CategoriesAvailable = new int[12];
    public static bool unlockUpgrade;
    public static int[] redoAvailable = new int[12];

    public static int[] quizNumberEN = new int[12];
    public static int[] CategoriesAvailableEN = new int[12];
    public static int[] redoAvailableEN = new int[12];


    private void Start()
	{
		if(SceneManager.GetActiveScene().name == "profile_scene")
		{
			string[] lines;

			if(!File.Exists("C:\\Users\\"+Environment.UserName+"\\Documents\\profile_1.vrumm"))
			{
				File.Create("C:\\Users\\"+Environment.UserName+"\\Documents\\profile_1.vrumm");
			}
			if (!File.Exists("C:\\Users\\" + Environment.UserName + "\\Documents\\profile_2.vrumm"))
			{
				File.Create("C:\\Users\\" + Environment.UserName + "\\Documents\\profile_2.vrumm");
			}
			if (!File.Exists("C:\\Users\\" + Environment.UserName + "\\Documents\\profile_3.vrumm"))
			{
				File.Create("C:\\Users\\" + Environment.UserName + "\\Documents\\profile_3.vrumm");
			}

			// pentru primu profil
			if (new FileInfo("C:\\Users\\" + Environment.UserName + "\\Documents\\profile_1.vrumm").Length == 0)
			{
				poze_puse[0].sprite = poza_goala;
				nume_profiluri[0].text = LanguageManager.language == "English" ? "Create Profile" : "Creeaza Profil";
            }
			else
			{
				profile_1_created = true;

				lines = File.ReadAllLines(address1);
				playerName = lines[0];
				age = Convert.ToInt32(lines[1]);
				picture_index = Convert.ToInt32(lines[2]);

				poze_puse[0].sprite = poze_profil[picture_index-1];
				nume_profiluri[0].text = playerName;
			}

			// pentru al doilea profil
			if (new FileInfo("C:\\Users\\" + Environment.UserName + "\\Documents\\profile_2.vrumm").Length == 0)
			{
				poze_puse[1].sprite = poza_goala;
				nume_profiluri[1].text = LanguageManager.language == "English" ? "Create Profile" : "Creeaza Profil";
            }
			else
			{
				profile_2_created = true;

				lines = File.ReadAllLines(address2);
				playerName = lines[0];
				age = Convert.ToInt32(lines[1]);
				picture_index = Convert.ToInt32(lines[2]);

				poze_puse[1].sprite = poze_profil[picture_index-1];
				nume_profiluri[1].text = playerName;
			}

			// pentru al treilea profill
			if (new FileInfo("C:\\Users\\" + Environment.UserName + "\\Documents\\profile_3.vrumm").Length == 0)
			{
				poze_puse[2].sprite = poza_goala;
				nume_profiluri[2].text = LanguageManager.language=="English" ? "Create Profile" : "Creeaza Profil";
			}
			else
			{
				profile_3_created = true;

				lines = File.ReadAllLines(address3);
				playerName = lines[0];
				age = Convert.ToInt32(lines[1]);
				picture_index = Convert.ToInt32(lines[2]);

				poze_puse[2].sprite = poze_profil[picture_index-1];
				nume_profiluri[2].text = playerName;
			}


		}
		else if(SceneManager.GetActiveScene().name == "main_scene")
		{
			Debug.Log("Loading data . . .");
			LoadData();
			Debug.Log("Name: " + playerName + "\nAge: " + age + "\nPicture: " + picture_index);
			profil_pic_ingame_MainScene.sprite = poze_profil[picture_index-1];
			player_name_MainScene.text = playerName;
			BaniCounter.text = bani.ToString();

			numar_piese[0].text = motoare.ToString();
			numar_piese[1].text = cutii.ToString();
			numar_piese[2].text = caroserii.ToString();
			numar_piese[3].text = roti.ToString();
			numar_piese[4].text = altele.ToString();

			if(masina)
			{
				CarManagerScript carManager = GameObject.Find("CarManager").GetComponent<CarManagerScript>();
				carManager.CreateCar();
			}
		}
		else if(SceneManager.GetActiveScene().name == "buy_parts")
		{
			BaniCounter.text = bani.ToString();
		}
		else if(SceneManager.GetActiveScene().name == "Upgrade")
		{
			BaniCounter.text = bani.ToString();

		}
		else if(SceneManager.GetActiveScene().name == "Profile_1")
		{
			profil_pic_ingame_MainScene.sprite = poze_profil[picture_index - 1];
			player_name_MainScene.text = playerName;
			BaniCounter.text = bani.ToString();
			ageText.text = age.ToString();
			soldCarsCounter.text = masini_vandute.ToString();
			totalEarningsText.text = totalEarnings.ToString();
			totalTimeCounter.text = days + " : " + hours + " : " + minutes + " : " + seconds;
		}
	}

	private void Update()
	{
		if(SceneManager.GetActiveScene().name == "main_scene")
		{
			numar_piese[0].text = motoare.ToString();
			numar_piese[1].text = cutii.ToString();
			numar_piese[2].text = caroserii.ToString();
			numar_piese[3].text = roti.ToString();
			numar_piese[4].text = altele.ToString();

			BaniCounter.text = bani.ToString();

			GiftCadou.timer += 1 * Time.deltaTime;
		}
		else if (SceneManager.GetActiveScene().name == "buy_parts")
		{
			BaniCounter.text = bani.ToString();
			GiftCadou.timer += 1 * Time.deltaTime;
		}
		else if (SceneManager.GetActiveScene().name == "Upgrade")
		{
			BaniCounter.text = bani.ToString();
			GiftCadou.timer += 1 * Time.deltaTime;
		}
		else if(SceneManager.GetActiveScene().name == "Profile_1")
		{
			GiftCadou.timer += 1 * Time.deltaTime;
			BaniCounter.text = bani.ToString();
			totalTimeCounter.text = (days < 10 ? "0" + days.ToString() : days.ToString()) + " : "
				+ (hours < 10 ? "0" + hours.ToString() : hours.ToString()) + " : " +
				(minutes < 10 ? "0" + minutes.ToString() : minutes.ToString()) + " : "
				+ (Convert.ToInt32(seconds) < 10 ? "0" + Convert.ToInt32(seconds).ToString() : Convert.ToInt32(seconds).ToString());
		}

		if(!(SceneManager.GetActiveScene().name == "create_profile" || SceneManager.GetActiveScene().name == "profile_scene"
			|| SceneManager.GetActiveScene().name == "settings" || SceneManager.GetActiveScene().name == "main_interface"))
		{
			seconds += 1 * Time.deltaTime;
			if(seconds>=60)
			{
				seconds = 0;
				minutes++;
			}
			if(minutes>=60)
			{
				minutes = 0;
				hours++;
			}
			if(hours >= 24)
			{
				hours = 0;
				days++;
			}
			SetData();
		}

	}

	public void SetProfileIndex(int profile)
	{
		profile_index = profile;
	}

	public void SetAge()
	{
		age = Convert.ToInt32(slider.value);
	}

	public void SetPictureIndex(int index)
	{
		picture_index = index;
	}

	public void SetName()
	{
		playerName = nameText.text;
		Debug.Log(profile_index);
	}

	public void Delete_Profile(int profil)
	{
		switch (profil)
		{
			case 1:
				if (File.Exists(address1))
				{
					File.WriteAllText(address1, String.Empty);
					profile_1_created = false;
					poze_puse[0].sprite = poza_goala;
                    nume_profiluri[0].text = LanguageManager.language == "English" ? "Create profile" : "Creeaza Profil";
				}
				break;
			case 2:
				if (File.Exists(address2))
				{
					File.WriteAllText(address2, String.Empty);
					profile_2_created = false;
					poze_puse[1].sprite = poza_goala;
                    nume_profiluri[1].text = LanguageManager.language == "English" ? "Create profile" : "Creeaza Profil";

                }
				break;
			case 3:
				if (File.Exists(address3))
				{
					File.WriteAllText(address3, String.Empty);
					profile_3_created = false;
					poze_puse[2].sprite = poza_goala;
                    nume_profiluri[2].text = LanguageManager.language == "English" ? "Create profile" : "Creeaza Profil";
                }
				break;
		}
		
	}

	public void CreateNewProfile()
	{
		bani = 5000;
		motoare = 0;
		cutii = 0;
		caroserii = 0;
		roti = 0;
		altele = 0;
		maxUpgradeProfit = 1;
		maxUpgradeQuality = 1;
		masina = false;
		seconds = 0;
		minutes = 0;
		hours = 0;
		days = 0;
		totalEarnings = 0;
		masini_vandute = 0;
		activeBackground = 1;
        for (int i=0; i<12;i++)
        {
            quizNumber[i] = 1;
            CategoriesAvailable[i] = 1;
            redoAvailable[i] = 0;
            quizNumberEN[i] = 1;
            CategoriesAvailableEN[i] = 1;
            redoAvailableEN[i] = 0;
        }
        unlockUpgrade = false;
	}

	public void SetData()
	{
        string dataString = playerName + '\n' + age.ToString() + '\n' + picture_index.ToString()
            + '\n' + bani.ToString() + '\n' + motoare.ToString() + '\n' + cutii.ToString()
            + '\n' + caroserii.ToString() + '\n' + roti.ToString() + '\n' + altele.ToString()
            + '\n' + maxUpgradeQuality.ToString() + '\n' + masina.ToString()
            + '\n' + masini_vandute.ToString() + '\n' + totalEarnings.ToString()
            + '\n' + seconds.ToString() + '\n' + minutes.ToString()
            + '\n' + hours.ToString() + '\n' + days.ToString()
            + '\n' + maxUpgradeProfit.ToString() + '\n' + activeBackground.ToString() + '\n' + quizNumber[0].ToString() + '\n' + quizNumber[1].ToString()
            + '\n' + quizNumber[2].ToString() + '\n' + quizNumber[3].ToString() + '\n' + quizNumber[4].ToString() + '\n' + quizNumber[5].ToString()
            + '\n' + quizNumber[6].ToString() + '\n' + quizNumber[7].ToString() + '\n' + quizNumber[8].ToString() + '\n' + quizNumber[9].ToString()
            + '\n' + quizNumber[10].ToString() + '\n' + quizNumber[11].ToString() + '\n' + CategoriesAvailable[0].ToString() + '\n' + CategoriesAvailable[1].ToString()
            + '\n' + CategoriesAvailable[2].ToString() + '\n' + CategoriesAvailable[3].ToString() + '\n' + CategoriesAvailable[4].ToString() + '\n' + CategoriesAvailable[5].ToString()
            + '\n' + CategoriesAvailable[6].ToString() + '\n' + CategoriesAvailable[7].ToString() + '\n' + CategoriesAvailable[8].ToString() + '\n' + CategoriesAvailable[9].ToString()
            + '\n' + CategoriesAvailable[10].ToString() + '\n' + CategoriesAvailable[11].ToString() + '\n' + unlockUpgrade.ToString() + '\n' + redoAvailable[0].ToString()
            + '\n' + redoAvailable[1].ToString() + '\n' + redoAvailable[2].ToString() + '\n' + redoAvailable[3].ToString() + '\n' + redoAvailable[4].ToString() + '\n' + redoAvailable[5].ToString()
            + '\n' + redoAvailable[6].ToString() + '\n' + redoAvailable[7].ToString() + '\n' + redoAvailable[8].ToString() + '\n' + redoAvailable[9].ToString() + '\n' + redoAvailable[10].ToString()
            + '\n' + redoAvailable[11].ToString() + '\n' +  quizNumberEN[0].ToString() + '\n' + quizNumberEN[1].ToString()
            + '\n' + quizNumberEN[2].ToString() + '\n' + quizNumberEN[3].ToString() + '\n' + quizNumberEN[4].ToString() + '\n' + quizNumberEN[5].ToString()
            + '\n' + quizNumberEN[6].ToString() + '\n' + quizNumberEN[7].ToString() + '\n' + quizNumberEN[8].ToString() + '\n' + quizNumberEN[9].ToString()
            + '\n' + quizNumberEN[10].ToString() + '\n' + quizNumberEN[11].ToString() + '\n' + CategoriesAvailableEN[0].ToString() + '\n' + CategoriesAvailableEN[1].ToString()
            + '\n' + CategoriesAvailableEN[2].ToString() + '\n' + CategoriesAvailableEN[3].ToString() + '\n' + CategoriesAvailableEN[4].ToString() + '\n' + CategoriesAvailableEN[5].ToString()
            + '\n' + CategoriesAvailableEN[6].ToString() + '\n' + CategoriesAvailableEN[7].ToString() + '\n' + CategoriesAvailableEN[8].ToString() + '\n' + CategoriesAvailableEN[9].ToString()
            + '\n' + CategoriesAvailableEN[10].ToString() + '\n' + CategoriesAvailableEN[11].ToString() + '\n' + redoAvailableEN[0].ToString()
            + '\n' + redoAvailableEN[1].ToString() + '\n' + redoAvailableEN[2].ToString() + '\n' + redoAvailableEN[3].ToString() + '\n' + redoAvailableEN[4].ToString() + '\n' + redoAvailableEN[5].ToString()
            + '\n' + redoAvailableEN[6].ToString() + '\n' + redoAvailableEN[7].ToString() + '\n' + redoAvailableEN[8].ToString() + '\n' + redoAvailableEN[9].ToString() + '\n' + redoAvailableEN[10].ToString()
            + '\n' + redoAvailableEN[11].ToString();
		switch (profile_index)
		{
			case 1:
				File.WriteAllText(address1, dataString);
				break;
			case 2:
				File.WriteAllText(address2, dataString);
				break;
			case 3:
				File.WriteAllText(address3, dataString);
				break;
			default:
				break;
		}
	}


	public static void LoadData()
	{
        int j;
        string[] lines;
		switch(profile_index)
		{
			case 1:
				lines = File.ReadAllLines("C:\\Users\\" + Environment.UserName + "\\Documents\\profile_1.vrumm");
                playerName = lines[0];
                age = Convert.ToInt32(lines[1]);
                picture_index = Convert.ToInt32(lines[2]);
                bani = Convert.ToUInt64(lines[3]);
                motoare = Convert.ToInt32(lines[4]);
                cutii = Convert.ToInt32(lines[5]);
                caroserii = Convert.ToInt32(lines[6]);
                roti = Convert.ToInt32(lines[7]);
                altele = Convert.ToInt32(lines[8]);
                maxUpgradeQuality = Convert.ToInt32(lines[9]);
                masina = Convert.ToBoolean(lines[10]);
                masini_vandute = Convert.ToInt32(lines[11]);
                totalEarnings = Convert.ToInt64(lines[12]);
                seconds = Convert.ToSingle(lines[13]);
                minutes = Convert.ToSingle(lines[14]);
                hours = Convert.ToSingle(lines[15]);
                days = Convert.ToSingle(lines[16]);
                maxUpgradeProfit = Convert.ToInt32(lines[17]);
                activeBackground = Convert.ToInt32(lines[18]);
                j = 19;
                for (int i = 0; i < 12; i++)
                {
                    quizNumber[i] = Convert.ToInt32(lines[j++]);
                }
                for (int i = 0; i < 12; i++)
                {
                    CategoriesAvailable[i] = Convert.ToInt32(lines[j++]);
                }
                unlockUpgrade = Convert.ToBoolean(lines[j++]);
                for (int i = 0; i < 12; i++)
                {
                    redoAvailable[i] = Convert.ToInt32(lines[j++]);
                }
                for (int i = 0; i < 12; i++)
                {
                    quizNumberEN[i] = Convert.ToInt32(lines[j++]);
                }
                for (int i = 0; i < 12; i++)
                {
                    CategoriesAvailableEN[i] = Convert.ToInt32(lines[j++]);
                }
                for (int i = 0; i < 12; i++)
                {
                    redoAvailableEN[i] = Convert.ToInt32(lines[j]);
                }
                break;
			case 2:
				lines = File.ReadAllLines("C:\\Users\\" + Environment.UserName + "\\Documents\\profile_2.vrumm");
                playerName = lines[0];
                age = Convert.ToInt32(lines[1]);
                picture_index = Convert.ToInt32(lines[2]);
                bani = Convert.ToUInt64(lines[3]);
                motoare = Convert.ToInt32(lines[4]);
                cutii = Convert.ToInt32(lines[5]);
                caroserii = Convert.ToInt32(lines[6]);
                roti = Convert.ToInt32(lines[7]);
                altele = Convert.ToInt32(lines[8]);
                maxUpgradeQuality = Convert.ToInt32(lines[9]);
                masina = Convert.ToBoolean(lines[10]);
                masini_vandute = Convert.ToInt32(lines[11]);
                totalEarnings = Convert.ToInt64(lines[12]);
                seconds = Convert.ToSingle(lines[13]);
                minutes = Convert.ToSingle(lines[14]);
                hours = Convert.ToSingle(lines[15]);
                days = Convert.ToSingle(lines[16]);
                maxUpgradeProfit = Convert.ToInt32(lines[17]);
                activeBackground = Convert.ToInt32(lines[18]);
                j = 19;
                for (int i = 0; i < 12; i++)
                {
                    quizNumber[i] = Convert.ToInt32(lines[j++]);
                }
                for (int i = 0; i < 12; i++)
                {
                    CategoriesAvailable[i] = Convert.ToInt32(lines[j++]);
                }
                unlockUpgrade = Convert.ToBoolean(lines[j++]);
                for (int i = 0; i < 12; i++)
                {
                    redoAvailable[i] = Convert.ToInt32(lines[j++]);
                }
                for (int i = 0; i < 12; i++)
                {
                    quizNumberEN[i] = Convert.ToInt32(lines[j++]);
                }
                for (int i = 0; i < 12; i++)
                {
                    CategoriesAvailableEN[i] = Convert.ToInt32(lines[j++]);
                }
                for (int i = 0; i < 12; i++)
                {
                    redoAvailableEN[i] = Convert.ToInt32(lines[j]);
                }
                break;
			case 3:
				lines = File.ReadAllLines("C:\\Users\\" + Environment.UserName + "\\Documents\\profile_3.vrumm");
                playerName = lines[0];
                age = Convert.ToInt32(lines[1]);
                picture_index = Convert.ToInt32(lines[2]);
                bani = Convert.ToUInt64(lines[3]);
                motoare = Convert.ToInt32(lines[4]);
                cutii = Convert.ToInt32(lines[5]);
                caroserii = Convert.ToInt32(lines[6]);
                roti = Convert.ToInt32(lines[7]);
                altele = Convert.ToInt32(lines[8]);
                maxUpgradeQuality = Convert.ToInt32(lines[9]);
                masina = Convert.ToBoolean(lines[10]);
                masini_vandute = Convert.ToInt32(lines[11]);
                totalEarnings = Convert.ToInt64(lines[12]);
                seconds = Convert.ToSingle(lines[13]);
                minutes = Convert.ToSingle(lines[14]);
                hours = Convert.ToSingle(lines[15]);
                days = Convert.ToSingle(lines[16]);
                maxUpgradeProfit = Convert.ToInt32(lines[17]);
                activeBackground = Convert.ToInt32(lines[18]);
                j = 19;
                for (int i = 0; i < 12; i++)
                {
                    quizNumber[i] = Convert.ToInt32(lines[j++]);
                }
                for (int i = 0; i < 12; i++)
                {
                    CategoriesAvailable[i] = Convert.ToInt32(lines[j++]);
                }
                unlockUpgrade = Convert.ToBoolean(lines[j++]);
                for (int i = 0; i < 12; i++)
                {
                    redoAvailable[i] = Convert.ToInt32(lines[j++]);
                }
                for (int i = 0; i < 12; i++)
                {
                    quizNumberEN[i] = Convert.ToInt32(lines[j++]);
                }
                for (int i = 0; i < 12; i++)
                {
                    CategoriesAvailableEN[i] = Convert.ToInt32(lines[j++]);
                }
                for (int i = 0; i < 12; i++)
                {
                    redoAvailableEN[i] = Convert.ToInt32(lines[j]);
                }
                break;
		}
	}
}
