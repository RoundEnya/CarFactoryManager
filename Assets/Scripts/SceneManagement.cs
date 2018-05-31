using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void LoadScene(string scene_name)
	{
		Debug.Log("Loading scene:" + scene_name);
		SceneManager.LoadScene(scene_name);
	}

	// TODO cere confirmare la asta
	public void CloseApp()
	{
		Debug.Log("Closing app");
		Application.Quit();
	}

	public void LoadProfile(int index)
	{
		switch(index)
		{
			case 1: 
				if(ProfileManager.profile_1_created)
				{
					LoadScene("main_scene");
				}
				else
				{
					LoadScene("create_profile");
				}
				break;
			case 2:
				if (ProfileManager.profile_2_created)
				{
					LoadScene("main_scene");
				}
				else
				{
					LoadScene("create_profile");
				}
				break;
			case 3:
				if (ProfileManager.profile_3_created)
				{
					LoadScene("main_scene");
				}
				else
				{
					LoadScene("create_profile");
				}
				break;
		}
	}

}
