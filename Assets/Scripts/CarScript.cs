using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarScript : MonoBehaviour
{
	public Transform center;
	public Transform outside;
	public bool sold = false;
	public bool reachedCenter = false;

	private int speed = 10;

	private int[] carPrices = new int[6];
	
	// Use this for initialization
	private void Start()
	{
		// Set center and outside transforms
		center = GameObject.Find("Center").transform;
		outside = GameObject.Find("Outside").transform;

		carPrices[0] = 3320;
		carPrices[1] = 112000;
		carPrices[2] = 322000;
		carPrices[3] = 1050000;
		carPrices[4] = 3110000;
		carPrices[5] = 8200000;
	}

	// Update is called once per frame
	private void Update()
	{
		// move car to center
		if(!reachedCenter)
		{
			ToCenter();

			// Daca ajunge in centru se opreste
			if(transform.position == center.position)
			{
				reachedCenter = true;
			}
		}

		// move car outside
		if(reachedCenter && sold)
		{
			ToOut();

			// Daca ajunge afara dispare
			if(transform.position == outside.position)
			{
				// Nu mai am masina
				ProfileManager.masina = false;

				// Iau banii
				ProfileManager.bani += Convert.ToUInt64(carPrices[ProfileManager.maxUpgradeQuality - 1] +
					carPrices[ProfileManager.maxUpgradeQuality - 1] * ProfileManager.procentProfit);
                ProfileManager.totalEarnings += Convert.ToInt64(carPrices[ProfileManager.maxUpgradeQuality - 1] +
                    carPrices[ProfileManager.maxUpgradeQuality - 1] * ProfileManager.procentProfit);

                // Creste numaratoarea de masini vandute
                ProfileManager.masini_vandute++;

                // Salvez astea
                ProfileManager PM = new ProfileManager();
				PM.SetData();

				// DANGER
				Destroy(gameObject);
			}
		}
	}

	/// <summary>
	/// Muta masina in "centru" (care e putin mai jos de centru)
	/// </summary>
	void ToCenter()
	{
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, center.position, step);
	}

	/// <summary>
	/// Muta masina afara
	/// </summary>
	void ToOut()
	{
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, outside.position, step);
	}
}
