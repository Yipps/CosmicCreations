using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInfo : MonoBehaviour {
    public float hydrogen;
    public float helium;
    public float carbon;
    public float oxygen;
    public float neon;
    public float silicon;
    public float iron;

    public int[] elementArray = new int[7];

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

    //makes the planet larger/smaller
    void Expand (float rad){
        gameObject.transform.localScale = new Vector3(rad, rad,rad);
    }

    //orbits the planet around the origin
    void Rotate() {
        transform.Rotate(Vector3.right*Time.deltaTime*10); 
    }

    //returns the distance from the Sun/origin as a vector quantity
    float DistFromSun() {
        float dist = transform.position.magnitude;
        return dist;
    }

    //ratio of metals to nm
    void ProcessElements(){

    }

    //dynamically change element ratio
    void AddElement(int planetIndex){

        //hydrogen
        if (elementArray[planetIndex] == 0) {
              
        }//helium
        else if (elementArray[planetIndex] == 1){

        }//carbon
        else if (elementArray[planetIndex] == 2){

        }//oxygen
        else if (elementArray[planetIndex] == 3){

        }//neon
        else if (elementArray[planetIndex] == 4){

        }//silicon
        else if (elementArray[planetIndex] == 5){

        }//iron
        else if (elementArray[planetIndex] == 6){

        }
        else {
            Debug.Log("this should be impossible");
        }

    }

}
