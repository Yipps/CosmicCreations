using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInfo : MonoBehaviour {
    public float hydrogen;
    public float helium;
    public float carbon;
    public float iron;
    public float oxygen;
    public float neon;
    public float silicon;

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
        distFromSun = DistFromSun();		
	}

    void Expand (float rad){
        gameObject.transform.localScale = new Vector3(rad, rad,rad);
    }

    void Rotate() {
        transform.Rotate(Vector3.right*Time.deltaTime*10); 
    }

    float DistFromSun() {
        float dist = transform.position.magnitude;
        return dist;
    }

}
