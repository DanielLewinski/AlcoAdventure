using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlcoholSelect : MonoBehaviour {

    public float BUTTONWIDTH = Screen.width/5;
    public float BUTTONHEIGHT = Screen.height/4;
    public float BREAKEWIDTH = Screen.width / 10;
    public float BREAKEHEIGHT = Screen.height / 16;

    //Kinds of alcohol textures in MENU
    public Texture[] alcoholTextures = new Texture[6];

    public enum AlcoholChoice
    {
        BEER,
        WINE,
        CHAMPAGNE,
        VODKA,
        SPIRIT,
        DENATURATE,
    };
    AlcoholChoice alcoholChoice = 0;

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

    //checking resolution in real time
    void CheckResolution()
    {
    BUTTONWIDTH = Screen.width / 5;
    BUTTONHEIGHT = Screen.height / 4;
    BREAKEWIDTH = Screen.width / 10;
    BREAKEHEIGHT = Screen.height / 16;
}

    void OnGUI()
    {
        //Alcohol MENU
        if (GUI.Button(new Rect(BREAKEWIDTH, BREAKEHEIGHT, BUTTONWIDTH, BUTTONHEIGHT), alcoholTextures[0]))
        {
            alcoholChoice = AlcoholChoice.BEER;
            Application.LoadLevel("VolumeSelect");
        }
        if (GUI.Button(new Rect(2 * BREAKEWIDTH + BUTTONWIDTH, BREAKEHEIGHT, BUTTONWIDTH, BUTTONHEIGHT), alcoholTextures[1]))
        {
            alcoholChoice = AlcoholChoice.WINE;
            Application.LoadLevel("VolumeSelect");
        }
        if (GUI.Button(new Rect(3 * BREAKEWIDTH + 2 * BUTTONWIDTH, BREAKEHEIGHT, BUTTONWIDTH, BUTTONHEIGHT), alcoholTextures[2]))
        {
            alcoholChoice = AlcoholChoice.CHAMPAGNE;
            Application.LoadLevel("VolumeSelect");
        }
        if (GUI.Button(new Rect(BREAKEWIDTH, 2 * BREAKEHEIGHT + BUTTONHEIGHT, BUTTONWIDTH, BUTTONHEIGHT), alcoholTextures[3]))
        {
            alcoholChoice = AlcoholChoice.VODKA;
            Application.LoadLevel("VolumeSelect");
        }
        if (GUI.Button(new Rect(2 * BREAKEWIDTH + BUTTONWIDTH, 2 * BREAKEHEIGHT + BUTTONHEIGHT, BUTTONWIDTH, BUTTONHEIGHT), alcoholTextures[4]))
        {
            alcoholChoice = AlcoholChoice.SPIRIT;
            Application.LoadLevel("VolumeSelect");
        }
        if (GUI.Button(new Rect(3 * BREAKEWIDTH + 2 * BUTTONWIDTH, 2 * BREAKEHEIGHT + BUTTONHEIGHT, BUTTONWIDTH, BUTTONHEIGHT), alcoholTextures[5]))
        {
            alcoholChoice = AlcoholChoice.DENATURATE;
            Application.LoadLevel("VolumeSelect");
        }
        if (GUI.Button(new Rect(BREAKEWIDTH, 3 * BREAKEHEIGHT + 2* BUTTONHEIGHT, 3*BUTTONWIDTH + 2*BREAKEWIDTH, BUTTONHEIGHT/2), "back"))
        {
            //Back
        }

        //sending kind of alco to VolumeSelect;
        VolumeSelect.alcoholSelected = (int)alcoholChoice;

    }
}
