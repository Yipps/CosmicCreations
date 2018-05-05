using System.Collections;
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
        List<int> elementsRanked = new List<int>(newPlanet.elementArray);

        int max = 1;
        int maxIndex = 0;
        while (max != 0)
        {
            for (int i = 0; i < elementsRanked.Count; i++)
            {
                if (elementsRanked[i] > max)
                {
                    max = elementsRanked[i];
                    maxIndex = i;
                }
            }

            PrintElement(maxIndex);
            elementsRanked[maxIndex] = 0;
        }

    }

    private void PrintElement(int index)
    {
        if (index == 0)
            planetStats.text += "H : " + ((float)newPlanet.hydrogen / newPlanet.total * 100).ToString("f1") + "%" + "\n";
        else if (index == 1)
            planetStats.text += "He: " + ((float)newPlanet.helium / newPlanet.total * 100).ToString("f1") + "%" + "\n";
        else if (index == 2)
            planetStats.text += "C : " + ((float)newPlanet.carbon / newPlanet.total * 100).ToString("f1") + "%" + "\n";
        else if (index == 3)
            planetStats.text += "O : " + ((float)newPlanet.oxygen / newPlanet.total * 100).ToString("f1") + "%" + "\n";
        else if (index == 4)
            planetStats.text += "Ne : " + ((float)newPlanet.neon / newPlanet.total * 100).ToString("f1") + "%" + "\n";
        else if (index == 5)
            planetStats.text += "Si: " + ((float)newPlanet.silicon / newPlanet.total * 100).ToString("f1") + "%" + "\n";
        else if (index == 6)
            planetStats.text += "Fe: " + ((float)newPlanet.iron / newPlanet.total * 100).ToString("f1") + "%" + "\n";
    }
}
