using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class BiometricData : MonoBehaviour 
{

	int BUTTON_WIDTH = Screen.width/5;
	int BUTTON_HEIGHT = Screen.width/20;

	string myName = "";
	string mass = "";
	string height = "";
	bool isMale = true;
	bool isStomachEmpty = false;

	void Start () 
	{
	
	}
	
	void Update () 
	{
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

	void OnGUI()
	{
		GUI.Label(new Rect(Screen.width / 5 * 2, Screen.height / 20*3, BUTTON_WIDTH, BUTTON_HEIGHT), "Name");
		myName = GUI.TextField(new Rect(Screen.width/5*2, Screen.height/10*2, BUTTON_WIDTH, BUTTON_HEIGHT), myName);

		GUI.Label(new Rect(Screen.width / 5 * 2, Screen.height / 20*7, BUTTON_WIDTH, BUTTON_HEIGHT), "Mass");
		mass = GUI.TextField(new Rect(Screen.width/5*2, Screen.height/10*4, BUTTON_WIDTH, BUTTON_HEIGHT), mass);
		mass = Regex.Replace(mass, @"[^0-9 ]", "");

		GUI.Label(new Rect(Screen.width / 5 * 2, Screen.height / 20*11, BUTTON_WIDTH, BUTTON_HEIGHT), "Height");
		height = GUI.TextField(new Rect(Screen.width/5*2, Screen.height/10*6, BUTTON_WIDTH, BUTTON_HEIGHT), height);
		height = Regex.Replace(height, @"[^0-9 ]", "");

		isMale = GUI.Toggle(new Rect(Screen.width/5, Screen.height/10*8, Screen.width/4, Screen.height/10), isMale, "Male/Female");

		isStomachEmpty = GUI.Toggle(new Rect(Screen.width/5*3, Screen.height/10*8, Screen.width/3, Screen.height/10), isStomachEmpty, "Have you eaten anything lately?");

		if(GUI.Button(new Rect(Screen.width/5*2, Screen.height/20*18, Screen.width/5, Screen.height/20), "Done"))
		{
			print(Drinker.Initialize(float.Parse(mass), float.Parse(height), isMale, isStomachEmpty, myName));
			Application.LoadLevel("AlcoholSelect");
		}
    }
}