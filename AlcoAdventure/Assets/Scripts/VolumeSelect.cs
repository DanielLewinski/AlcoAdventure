﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shot
{
    List<int> amount = new List<int>(); // list of access volumes
    public float power = 0; // power of alko (%)

    /*public Shot(List<int> amount, int power)
    {
        this.amount = amount;
        this.power = power;
    }*/

    public List<int> Amount
    {
        get
        {
            return amount;
        }
        set
        {
            amount = value;
        }
    }

    public float Power
    {
        get
        {
            return power;
        }
        set
        {
            power = value;
        }
    }
}

public class VolumeSelect : MonoBehaviour {

    //information from AlcoholSelect about kind of alcohol
    public static int alcoholSelected;

    public float BUTTONWIDTH = Screen.width / 5;
    public float BUTTONHEIGHT = Screen.height / 4;
    public float BREAKEWIDTH = Screen.width / 10;
    public float BREAKEHEIGHT = Screen.height / 16;

    //textures of alcohol amount
    public Texture[] amountTextures = new Texture[9];

    //declaration of Shot class
    public Shot shot;
    public float alcoholMass;


    // Use this for initialization
    void Start () {
        CreateShot();
        if (!Drinker.isInitialized)
            print(Drinker.Initialize(75, 185, true, true));
    }
	
	// Update is called once per frame
	void Update () {
        string message = Drinker.UpdateStatus();
        if (message != "")
            print(message);
	}

    void CreateShot()
    {
        if(alcoholSelected == 0)
        {
            //BEER
            shot = new Shot();
            shot.Amount.Add(300);
            shot.Amount.Add(500);
            shot.Amount.Add(1000);

            shot.Power = 5;
        }
        else if(alcoholSelected == 1 || alcoholSelected == 2)
        {
            //wine or champagne
            shot = new Shot();
            shot.Amount.Add(300/2);
            shot.Amount.Add(500/2);
            shot.Amount.Add(1000/2);

            shot.Power = 12;
        }else
        {
            //vodka spirit denaturate
            shot = new Shot();
            shot.Amount.Add(300 / 10);
            shot.Amount.Add(500 / 10);
            shot.Amount.Add(1000 / 10);

            if(alcoholSelected == 3)
            {
                shot.Power = 40;
            }
            else if(alcoholSelected == 4)
            {
                shot.Power = 95;
            }
            else
            {
                shot.Power = 92;
            }
        }
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

        //Alcohol selection
        if (GUI.Button(new Rect(BREAKEWIDTH, BREAKEHEIGHT, BUTTONWIDTH, BUTTONHEIGHT), "small"))
        {
            ///Calculating mass of alkohol
            alcoholMass = 0.798f * shot.Amount[0] * (shot.Power/100);
            Drinker.Drink(alcoholMass);
        }
        if (GUI.Button(new Rect(2 * BREAKEWIDTH + BUTTONWIDTH, BREAKEHEIGHT, BUTTONWIDTH, BUTTONHEIGHT), "medium"))
        {
            alcoholMass = 0.798f * shot.Amount[1] * (shot.Power / 100);
            Drinker.Drink(alcoholMass);
        }
        if (GUI.Button(new Rect(3 * BREAKEWIDTH + 2 * BUTTONWIDTH, BREAKEHEIGHT, BUTTONWIDTH, BUTTONHEIGHT), "high"))
        {
            alcoholMass = 0.798f * shot.Amount[2] * (shot.Power / 100);
            Drinker.Drink(alcoholMass);
        }
        if (GUI.Button(new Rect(BREAKEWIDTH, 3 * BREAKEHEIGHT + 2 * BUTTONHEIGHT, 3 * BUTTONWIDTH + 2 * BREAKEWIDTH, BUTTONHEIGHT / 2), "Back"))
        {
            Application.LoadLevel("AlcoholSelect");
        }
    }
}