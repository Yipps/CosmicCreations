using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInfo : MonoBehaviour {
    public int hydrogen = 25;
    public int helium = 20;
    public int carbon = 15;
    public int oxygen = 15;
    public int neon = 5;
    public int silicon = 10;
    public int iron = 10;
    public bool atmosphere = false;

    public int total;
    public int layers;
    public int totalSolids;
    public int someGases;

    public int[] elementArray = new int[7];
    public int[] layerSizes = new int[3];

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

    //total amt of elements
    void ProcessElements(){
        total = hydrogen + helium + carbon + oxygen + neon + silicon + iron;
        totalSolids = carbon + silicon + iron;
        someGases = oxygen + neon;
    }

    //layer generation for cross sections
    //if only gases or only solids selected - only one layer
    //if the percentage of solids is <30%, three layers
    //else - two layers
    //sizes of layers
    // if one layer then size is 1
    //if three layers, inner layer 
    void CrossSection(){
        if (totalSolids == 0 || (total - totalSolids) == 0)
        {
            layers = 1;
            layerSizes[0] = 1; 
        }
        else if ((totalSolids / total) * 100 < 30)
        {
            layers = 3;
            layerSizes[0] = 1 - (totalSolids/total); 
            layerSizes[1] = 1 - (someGases/total); 
            layerSizes[2] = 1 - (layerSizes[0] + layerSizes[1]);  
        } 
        else
        {
            layers = 2;
            layerSizes[0] = totalSolids/total; 
            layerSizes[1] = 1 - layerSizes[0]; 
        }
    }
    //dynamically change element ratio
    void AddElement(int planetIndex){
        if (total < 100)
        {
            //hydrogen
            if (elementArray[planetIndex] == 0)
            {
                if (hydrogen < 40)
                    hydrogen++;
            }//helium
            else if (elementArray[planetIndex] == 1)
            {
                if (helium < 30)
                    helium++;
            }//carbon
            else if (elementArray[planetIndex] == 2)
            {
                if (carbon < 20)
                    carbon++;
            }//oxygen
            else if (elementArray[planetIndex] == 3)
            {
                if (oxygen < 20)
                    oxygen++;
            }//neon
            else if (elementArray[planetIndex] == 4)
            {
                if (neon < 10)
                    neon++;
            }//silicon
            else if (elementArray[planetIndex] == 5)
            {
                if (silicon < 20)
                    silicon++;
            }//iron
            else if (elementArray[planetIndex] == 6)
            {
                if (iron < 20)
                    iron++;
            }
            else
            {
                Debug.Log("this should be impossible");
            }
        }
        ProcessElements();
        CrossSection();
    }

    void SubtractElement(int planetIndex)
    {
        //hydrogen
        if (elementArray[planetIndex] == 0)
        {
            if (hydrogen > 10)
                hydrogen--;
        }//helium
        else if (elementArray[planetIndex] == 1)
        {
            if (helium > 5)
                helium--;
        }//carbon
        else if (elementArray[planetIndex] == 2)
        {
            if (carbon > 1)
                carbon--;
        }//oxygen
        else if (elementArray[planetIndex] == 3)
        {
            if (oxygen > 1)
                oxygen--;
        }//neon
        else if (elementArray[planetIndex] == 4)
        {
            if (neon > 1)
                neon--;
        }//silicon
        else if (elementArray[planetIndex] == 5)
        {
            if (silicon > 0)
                silicon--;
        }//iron
        else if (elementArray[planetIndex] == 6)
        {
            if (iron > 0)
                iron--;
        }
        else
       {
            Debug.Log("this should be impossible");
        }
        ProcessElements();
        CrossSection();
    }
}
