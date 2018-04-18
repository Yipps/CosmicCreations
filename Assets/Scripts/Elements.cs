using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Elements : MonoBehaviour {

    public Text elementTextbox;
    public PlanetInfo planet;

	//Use this for initialization
	void Start () {
         getInfo(planet);
	}
	
	// Update is called once per frame
	void Update () {
      
	}

    void getInfo(PlanetInfo info) {
        if (info.hydrogen != 0)
        {
            elementTextbox.text += "H " + info.hydrogen + "\n";
        }
        if (info.helium != 0)
        {
            elementTextbox.text += "He " + info.helium + "\n";
        }
        if (info.carbon != 0)
        {
            elementTextbox.text += "C " + info.carbon + "\n";
        }
        if (info.iron != 0)
        {
            elementTextbox.text += "Fe " + info.iron + "\n";
        }
        if (info.oxygen != 0)
        {
            elementTextbox.text += "O " + info.oxygen + "\n";
        }
        if (info.neon != 0)
        {
            elementTextbox.text += "Ne " + info.neon + "\n";
        }
        if (info.silicon != 0)
        {
            elementTextbox.text += "Si " + info.silicon + "\n";
        }
    }
}
