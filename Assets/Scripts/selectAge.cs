using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectAge : MonoBehaviour {

    public static int age;
    public Text ageText;

	// Use this for initialization
	void Start ()
    {
		age = Convert.ToInt32(GetComponent<Slider>().value);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ChangeAge()
    {
        age = Convert.ToInt32(GetComponent<Slider>().value);
        ageText.text = (LanguageManager.language == "English" ? "Age: " : "Vârstă: ") + age.ToString();
    }
}
