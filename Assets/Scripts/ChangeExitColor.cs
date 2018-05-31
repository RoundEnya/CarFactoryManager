using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeExitColor : MonoBehaviour {

	Color mouseOverColor;
	Color defaultColor;

	// Use this for initialization
	void Start ()
	{
		mouseOverColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		defaultColor = this.GetComponent<SpriteRenderer>().color;
	}

	private void OnMouseOver()
	{
		this.GetComponent<SpriteRenderer>().color = mouseOverColor;
	}

	private void OnMouseExit()
	{
		this.GetComponent<SpriteRenderer>().color = defaultColor;
	}

	private void OnMouseDown()
	{
		SaveGame();
		SceneManager.LoadScene("main_interface");
	}

	void SaveGame()
	{

	}
}
