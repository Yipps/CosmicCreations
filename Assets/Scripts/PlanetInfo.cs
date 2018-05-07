using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlanetInfo : MonoBehaviour {
    public int[] elementArray = new int[7];
    //set the values in the array as well when the Start method is called
    public int hydrogen = 25;
    public int helium = 20;
    public int carbon = 15;
    public int oxygen = 15;
    public int neon = 5;
    public int silicon = 10;
    public int iron = 10;

    public bool atmosphere = false;

    public int total;
    public int layers = 1;
    public int totalSolids;
    public int someGases;


    public float[] layerSizes = new float[3];

    public float radius;
    public float mass;
    public float distFromSun;


	// Use this for initialization
	void Start () {
        elementArray[0] = hydrogen;
        elementArray[1] = helium;
        elementArray[2] = carbon;
        elementArray[3] = oxygen;
        elementArray[4] = neon;
        elementArray[5] = silicon;
        elementArray[6] = iron;

        layerSizes[0] = 1;
        layerSizes[1] = 0;
        layerSizes[2] = 0;

        //need to call at start once to initialize the layers at 
        ProcessElements();
        CrossSection();
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
        total = elementArray.Sum();
        //carbon + si + iron
        totalSolids = elementArray[2] + elementArray[5] + elementArray[6];
        //oxygen + neon
        someGases = elementArray[3] + elementArray[4];
    }

    //layer generation for cross sections
    //if only gases or only solids selected - only one layer
    //if the percentage of solids is <30%, three layers
    //else - two layers
    //sizes of layers
    // if one layer then size is 1
    //if three layers, inner layer is 1- ratio of solids 

    void CrossSection(){
        if (totalSolids == 0 || (total - totalSolids) == 0)
        {
            layers = 1;
            layerSizes[0] = 1;
            layerSizes[1] = 0;
            layerSizes[2] = 0;
        }
        else if (((float)totalSolids / total) * 100 < 30)
        {
            layers = 3;
            layerSizes[0] = 1 - ((float)totalSolids/total); 
            layerSizes[1] = 1 - ((float)someGases/total); 
            layerSizes[2] = 1 - ((float)layerSizes[0] + layerSizes[1]);  
        } 
        else
        {
            layers = 2;
            layerSizes[0] = totalSolids/total; 
            layerSizes[1] = 1 - layerSizes[0];
            layerSizes[2] = 0;
        }
    }
    //dynamically change element ratio
    public void AddElement(int planetIndex){
        if (total < 150)
        {
            //hydrogen
            if (planetIndex == 0)
            {
                if (hydrogen < 40)
                    hydrogen++;
                elementArray[0] = hydrogen;

            }//helium
            else if (planetIndex == 1)
            {
                if (helium < 30)
                    helium++;
                elementArray[1] = helium;
            }//carbon
            else if (planetIndex == 2)
            {
                if (carbon < 20)
                    carbon++;
                elementArray[2] = carbon;
            }//oxygen
            else if (planetIndex == 3)
            {
                if (oxygen < 20)
                    oxygen++;
                elementArray[3] = oxygen;
            }//neon
            else if (planetIndex == 4)
            {
                if (neon < 10)
                    neon++;
                elementArray[4] = neon;
            }//silicon
            else if (planetIndex == 5)
            {
                if (silicon < 20)
                    silicon++;
                elementArray[5] = silicon;
            }//iron
            else if (planetIndex == 6)
            {
                if (iron < 20)
                    iron++;
                elementArray[6] = iron;
            }
            else
            {
                Debug.Log("this should be impossible");
            }
        }
        ProcessElements();
        CrossSection();
    }

    //public void SubtractElement(int planetIndex)
    //{
    //    //hydrogen
    //    if (planetIndex == 0)
    //    {
    //        if (hydrogen > 1)
    //            hydrogen--;
    //        elementArray[0] = hydrogen;
    //    }//helium
    //    else if (planetIndex == 1)
    //    {
    //        if (helium > 0)
    //            helium--;
    //        elementArray[1] = helium;
    //    }//carbon
    //    else if (planetIndex == 2)
    //    {
    //        if (carbon > 0)
    //            carbon--;
    //        elementArray[2] = carbon;
    //    }//oxygen
    //    else if (planetIndex == 3)
    //    {
    //        if (oxygen > 0)
    //            oxygen--;
    //        elementArray[3] = oxygen;
    //    }//neon
    //    else if (planetIndex== 4)
    //    {
    //        if (neon > 0)
    //            neon--;
    //        elementArray[4] = neon;
    //    }//silicon
    //    else if (planetIndex == 5)
    //    {
    //        if (silicon > 0)
    //            silicon--;
    //        elementArray[5] = silicon;
    //    }//iron
    //    else if (planetIndex == 6)
    //    {
    //        if (iron > 0)
    //            iron--;
    //        elementArray[6] = iron;
    //    }
    //    else
    //   {
    //        Debug.Log("this should be impossible");
    //    }
    //    ProcessElements();
    //    CrossSection();
    //}
}
