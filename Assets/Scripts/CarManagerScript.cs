using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarManagerScript : MonoBehaviour {

	public GameObject carPrefab;

	public Button button_assemble;
	public Button button_sell;

	private GameObject Car;
	private int[] carPrices;

	// Use this for initialization
	private void Start()
	{
		carPrices = new int[6];
		carPrices[0] = 3320;
		carPrices[1] = 112000;
		carPrices[2] = 322000;
		carPrices[3] = 1050000;
		carPrices[4] = 3110000;
		carPrices[5] = 8200000;

		CheckIfCanAssemble();
		CheckIfCanSell();
	}

	// Update is called once per frame
	private void Update()
	{
		CheckIfCanAssemble();
		CheckIfCanSell();
	}

	/// <summary>
	/// Face masina la o pozitie smechera si mai taie din piese da-le dracu
	/// </summary>
	public void AssembleCar()
	{
		Car = Instantiate(carPrefab, new Vector3(-11.0f, -7.25f, -1.0f), Quaternion.identity);

		// Scad cate o piesa din fiecare tip
		ProfileManager.motoare--;
		ProfileManager.cutii--;
		ProfileManager.roti--;
		ProfileManager.caroserii--;
		ProfileManager.altele--;

		// Am masina
		ProfileManager.masina = true;

		// Salvez astea
		ProfileManager PM = new ProfileManager();
		PM.SetData();
	}

	/// <summary>
	/// Doar creeaza masina la pozitia aia smechera de mai sus
	/// </summary>
	public void CreateCar()
	{
		Car = Instantiate(carPrefab, new Vector3(-11.0f, -7.25f, -1.0f), Quaternion.identity);
	}

	/// <summary>
	/// Vinde masina 
	/// Ia banii si o face sa se duca in dreapta
	/// </summary>
	public void SellCar()
	{
		// Tin minte ca am vandut-o ca sa o mut in CarScript.cs
		CarScript carScript = GameObject.FindGameObjectWithTag("Car").GetComponent<CarScript>();
		carScript.sold = true;
	}

	/// <summary>
	/// Verifica daca am masina ca sa am ce vinde
	/// Si activeaza butonu
	/// </summary>
	void CheckIfCanSell()
	{
		if(ProfileManager.masina == true && Car.GetComponent<CarScript>().reachedCenter)
		{
			button_sell.enabled = true;
		}
		else
		{
			button_sell.enabled = false;
		}
	}

	void CheckIfCanAssemble()
	{
		if(!ProfileManager.masina && (ProfileManager.motoare >= 1
			&& ProfileManager.cutii >= 1 && ProfileManager.roti >= 1
			&& ProfileManager.caroserii >= 1 && ProfileManager.altele >= 1))
		{
			button_assemble.enabled = true;
		}
		else
		{
			button_assemble.enabled = false;
		}
	}
}
