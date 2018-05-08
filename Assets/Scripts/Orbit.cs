using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {
    PlanetInfo planetInfo;

    public float orbitSpeed;
    public float curSpeed;

    void Start()
    {
        planetInfo = GetComponent<PlanetInfo>();
        orbitSpeed = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        //normalized the math stuff
        //so that planets that are farther orbit faster
        curSpeed = orbitSpeed / Mathf.Sqrt(planetInfo.distFromSun);
        transform.RotateAround(Vector3.zero, Vector3.up, curSpeed * Time.deltaTime * 180 / (2 * Mathf.PI * planetInfo.distFromSun));
    }


}
