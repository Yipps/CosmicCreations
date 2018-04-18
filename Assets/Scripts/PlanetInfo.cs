using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInfo : MonoBehaviour {
    public float hydrogen;
    public float helium;
    public float carbon;
    public float nitrogen;

    public float radius;
    public float mass;
    public float distFromSun;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //expand(radius);
        Rotate();
		
	}

    void Expand (float rad){
        gameObject.transform.localScale = new Vector3(rad, rad,rad);
    }


    void Rotate() {
        transform.Rotate(Vector3.right*Time.deltaTime*10); 
    }
}
