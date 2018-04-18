using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class elements : MonoBehaviour {

    public Text elementTextbox;
    public planetInfo planet;
	//Use this for initialization
	void Start () {
         getInfo(planet);
	}
	
	// Update is called once per frame
	void Update () {
      
	}

    void getInfo(planetInfo info) {
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
        if (info.nitrogen != 0)
        {
            elementTextbox.text += "N " + info.nitrogen + "\n";
        }
    }
}
