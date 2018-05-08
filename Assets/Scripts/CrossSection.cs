using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossSection : MonoBehaviour {

    public PlanetInfo newPlanet;
    public int CrossSectionIndex;

	// Use this for initialization
	void Start () {
        UpdateCrossSection();
	}

    // Update is called once per frame
    public void UpdateCrossSection()
    {
        transform.localScale = new Vector3(newPlanet.layerSizes[CrossSectionIndex], newPlanet.layerSizes[CrossSectionIndex], newPlanet.layerSizes[CrossSectionIndex]);
    }
}
