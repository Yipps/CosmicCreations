using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {
    PlanetInfo planetInfo; 
    void Start () {
        planetInfo = GetComponent<PlanetInfo>();
	}

    // Update is called once per frame
    void Update()
    {
        //normalized the math stuff
        //so that planets that are farther orbit slower
        //then I randomized the angle from 20, 90 so that all the orbits dont happen at the same speed
        transform.RotateAround(Vector3.zero, Vector3.up, (((planetInfo.distFromSun - 0)/(10))*-1) * Time.deltaTime*Random.Range(20,90));
    }


}
