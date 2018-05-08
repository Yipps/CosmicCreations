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
        if (info.elementArray[0] != 0)
        {
            elementTextbox.text += "H " + info.elementArray[0] + "\n";
        }
        if (info.elementArray[1] != 0)
        {
            elementTextbox.text += "He " + info.elementArray[1] + "\n";
        }
        if (info.elementArray[2] != 0)
        {
            elementTextbox.text += "C " + info.elementArray[2] + "\n";
        }
        if (info.elementArray[3] != 0)
        {
            elementTextbox.text += "O " + info.elementArray[3] + "\n";
        }
        if (info.elementArray[4] != 0)
        {
            elementTextbox.text += "Ne " + info.elementArray[4] + "\n";
        }
        if (info.elementArray[5] != 0)
        {
            elementTextbox.text += "Si " + info.elementArray[5] + "\n";
        }
        if (info.elementArray[6] != 0)
        {
            elementTextbox.text += "Fe " + info.elementArray[6] + "\n";
        }
    }
}
