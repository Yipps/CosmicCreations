using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemControl : MonoBehaviour {

    public bool canMovePlanet;
    public Transform hand;
    public Transform planet;
    public bool isLeftHandActive {get; set;}

	// Use this for initialization
	void Start () {
        DisablePositioningPlanet();
	}
	
	// Update is called once per frame
	void Update () {
        if (canMovePlanet)
            UpdatePlanetPosition();
	}

    void UpdatePlanetPosition()
    {
        planet.position = new Vector3(hand.position.x, planet.position.y, hand.position.z);
    }

    public void EnabledPositioningPlanet()
    {
        if (!isLeftHandActive)
        {
            canMovePlanet = true;
            planet.gameObject.GetComponent<Orbit>().enabled = false;
        }
    }

    public void DisablePositioningPlanet()
    {
            canMovePlanet = false;
            planet.gameObject.GetComponent<Orbit>().enabled = true;
    }

}
