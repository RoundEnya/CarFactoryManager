using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChanger : MonoBehaviour {

	bool moveRight = false;
	bool moveLeft = false;

	public float speed = 2.5f;
	public Button button_nextBg;
	public Button button_prevBg;
	
	// Update is called once per frame
	void Update ()
	{
		if(moveRight && ProfileManager.activeBackground <= 6)
		{
			this.transform.Translate(Vector3.left * Time.deltaTime * speed);


			if(this.transform.position.x <= (-1) * ((ProfileManager.activeBackground - 1) * 18))
			{
				moveRight = false;
				button_nextBg.enabled = true;
			}
		}
		else if(moveLeft && ProfileManager.activeBackground >= 1)
		{
			this.transform.Translate(Vector3.right * Time.deltaTime * speed);

			if (this.transform.position.x >= (-1) * ((ProfileManager.activeBackground - 1) * 18))
			{
				moveLeft = false;
				button_prevBg.enabled = true;
			}
		}
	}

	public void	ChangeBGRight()
	{
		if (ProfileManager.activeBackground < 6 && ProfileManager.activeBackground < ProfileManager.maxUpgradeQuality)
		{
			ProfileManager.activeBackground++;
			moveRight = true;
			button_nextBg.enabled = false;

			ProfileManager PM = new ProfileManager();
			PM.SetData ();
		}
	}

	public void ChangeBGLeft()
	{
		if (ProfileManager.activeBackground > 1)
		{
			ProfileManager.activeBackground--;
			moveLeft = true;
			button_prevBg.enabled = false;

			ProfileManager PM = new ProfileManager();
			PM.SetData ();
		}
	}
}
