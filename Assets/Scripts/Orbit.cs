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
        transform.RotateAround(Vector3.zero, Vector3.up, (((planetInfo.distFromSun - 0)/(10))*-1) * Time.deltaTime*Random.Range(20,90));
    }


}
