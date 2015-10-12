using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

    public float BUTTONWIDTH = Screen.width / 5;
    public float BUTTONHEIGHT = Screen.height / 4;
    public float BREAKEWIDTH = Screen.width / 10;
    public float BREAKEHEIGHT = Screen.height / 16;

    public Texture[] amountTextures = new Texture[2];

    public static float alcoholMass = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        CheckResolution();
        string message = Drinker.UpdateStatus();
        if (message != "")
            print(message);

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    void CheckResolution()
    {
        BUTTONWIDTH = Screen.width / 5;
        BUTTONHEIGHT = Screen.height / 4;
        BREAKEWIDTH = Screen.width / 10;
        BREAKEHEIGHT = Screen.height / 16;
    }


    void OnGUI()
    {
        //promils


        string message = "Alcohol level: " + Drinker.CalculatePromils().ToString() + "‰";
        GUI.Label(new Rect(10, 10, 100, 20), "Alcohol level: ");
        GUI.Label(new Rect(10, 25, 100, 20), Drinker.CalculatePromils().ToString() + "‰");
        GUI.Label(new Rect(10, 40, 100, 20), "Sober by: ");
        GUI.Label(new Rect(10, 55, 100, 20), Drinker.soberingTime.Hour.ToString() +":"+ Drinker.soberingTime.Minute.ToString());
        GUI.Label(new Rect(10, 70, 100, 20), Drinker.soberingTime.Day.ToString() + "." + Drinker.soberingTime.Month.ToString()+ "." + Drinker.soberingTime.Year.ToString());


        //Alcohol MENU
        if (GUI.Button(new Rect(3 * BREAKEWIDTH + 2 * BUTTONWIDTH, 0.575f*Screen.height, BUTTONWIDTH, BUTTONHEIGHT), amountTextures[0]))
        {
            print("asds");
            Drinker.Drink(alcoholMass);
       
        }

        if (GUI.Button(new Rect(BREAKEWIDTH, 0.85f*Screen.height, 3 * BUTTONWIDTH + 2 * BREAKEWIDTH, BUTTONHEIGHT / 2), amountTextures[1]))
        {
            Application.LoadLevel("AlcoholSelect");
        }

    }

    void Drinking()
    {
        //drinking
        if (VolumeSelect.alcoholSelected == 0)
        {

            if (VolumeSelect.amount == 0)
            {
                alcoholMass = 300 * 0.798f * (5 / 100);
            }
            else if (VolumeSelect.amount == 1)
            {
                alcoholMass = 500 * 0.798f * (5 / 100);
            }
            else
            {
                alcoholMass = 1000 * 0.798f * (5 / 100);
            }


        }
        else if (VolumeSelect.alcoholSelected == 1 || VolumeSelect.alcoholSelected == 2)
        {
            if (VolumeSelect.amount == 0)
            {
                alcoholMass = 150 * 0.798f * (12 / 100);
            }
            else if (VolumeSelect.amount == 1)
            {
                alcoholMass = 250 * 0.798f * (12 / 100);
            }
            else
            {
                alcoholMass = 500 * 0.798f * (12 / 100);
            }
        }
        else if (VolumeSelect.alcoholSelected == 3)
        {
            if (VolumeSelect.amount == 0)
            {
                alcoholMass = 30 * 0.798f * (40 / 100);
            }
            else if (VolumeSelect.amount == 1)
            {
                alcoholMass = 50 * 0.798f * (40 / 100);
            }
            else
            {
                alcoholMass = 100 * 0.798f * (40 / 100);
            }
        }if (VolumeSelect.alcoholSelected == 4)
        {
            if (VolumeSelect.amount == 0)
            {
                alcoholMass = 30 * 0.798f * (95 / 100);
            }
            else if (VolumeSelect.amount == 1)
            {
                alcoholMass = 50 * 0.798f * (95 / 100);
            }
            else
            {
                alcoholMass = 100 * 0.798f * (95 / 100);
            }
        }else
        {
            if (VolumeSelect.amount == 0)
            {
                alcoholMass = 30 * 0.798f * (92 / 100);
            }
            else if (VolumeSelect.amount == 1)
            {
                alcoholMass = 50 * 0.798f * (92 / 100);
            }
            else
            {
                alcoholMass = 100 * 0.798f * (92 / 100);
            }
        }
    }

}
