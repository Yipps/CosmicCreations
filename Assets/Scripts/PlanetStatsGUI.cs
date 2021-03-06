﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetStatsGUI : MonoBehaviour {

    public PlanetInfo newPlanet;
    public Text planetStats;

    public int[] orderedElements;
	// Use this for initialization
	void Start () {
        UpdateStats();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateStats()
    {
        planetStats.text = "";

            if (newPlanet.elementArray[0] != 0)
            planetStats.text += "H : " + ((float)newPlanet.elementArray[0] / newPlanet.total * 100).ToString("f1") + "%" + "\n";
            if (newPlanet.elementArray[1] != 0)
            planetStats.text += "He: " + ((float)newPlanet.elementArray[1] / newPlanet.total * 100).ToString("f1") + "%" + "\n";
            if (newPlanet.elementArray[2] != 0)
            planetStats.text += "C : " + ((float)newPlanet.elementArray[2] / newPlanet.total * 100).ToString("f1") + "%" + "\n";
            if (newPlanet.elementArray[3] != 0)
            planetStats.text += "O : " + ((float)newPlanet.elementArray[3] / newPlanet.total * 100).ToString("f1") + "%" + "\n";
            if (newPlanet.elementArray[4] != 0)
            planetStats.text += "Ne : " + ((float)newPlanet.elementArray[4] / newPlanet.total * 100).ToString("f1") + "%" + "\n";
            if (newPlanet.elementArray[5] != 0)
            planetStats.text += "Si: " + ((float)newPlanet.elementArray[5] / newPlanet.total * 100).ToString("f1") + "%" + "\n";
            if (newPlanet.elementArray[6] != 0)
            planetStats.text += "Fe: " + ((float)newPlanet.elementArray[6] / newPlanet.total * 100).ToString("f1") + "%" + "\n";

        //List<int> elementsRanked = new List<int>(newPlanet.elementArray);

        //int max = 1;
        //int maxIndex = 0;
        //while (max != 0)
        //{
        //    for (int i = 0; i < elementsRanked.Count; i++)
        //    {
        //        if (elementsRanked[i] > max)
        //        {
        //            max = elementsRanked[i];
        //            maxIndex = i;
        //        }
        //    }

        //    PrintElement(maxIndex);
        //    elementsRanked[maxIndex] = 0;
        //}

    }

    private void PrintElement(int index)
    {
        if (index == 0)
            planetStats.text += "H : " + ((float)newPlanet.elementArray[0] / newPlanet.total * 100).ToString("f1") + "%" + "\n";
        else if (index == 1)
            planetStats.text += "He: " + ((float)newPlanet.elementArray[1] / newPlanet.total * 100).ToString("f1") + "%" + "\n";
        else if (index == 2)
            planetStats.text += "C : " + ((float)newPlanet.elementArray[2] / newPlanet.total * 100).ToString("f1") + "%" + "\n";
        else if (index == 3)
            planetStats.text += "O : " + ((float)newPlanet.elementArray[3] / newPlanet.total * 100).ToString("f1") + "%" + "\n";
        else if (index == 4)
            planetStats.text += "Ne : " + ((float)newPlanet.elementArray[4] / newPlanet.total * 100).ToString("f1") + "%" + "\n";
        else if (index == 5)
            planetStats.text += "Si: " + ((float)newPlanet.elementArray[5] / newPlanet.total * 100).ToString("f1") + "%" + "\n";
        else if (index == 6)
            planetStats.text += "Fe: " + ((float)newPlanet.elementArray[6] / newPlanet.total * 100).ToString("f1") + "%" + "\n";
    }
}
